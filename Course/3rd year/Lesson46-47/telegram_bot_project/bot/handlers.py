from telegram import Update, ReplyKeyboardMarkup
from telegram.ext import ContextTypes, ConversationHandler, CommandHandler, MessageHandler, filters
from bot.database import SessionLocal, User, Role
import re

# Шаги диалога
ASK_NAME, ASK_SURNAME = range(2)

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    session = SessionLocal()
    user_id = update.effective_user.id

    user = session.query(User).filter_by(telegram_id=user_id).first()

    if user:
        await update.message.reply_text(f"С возвращением, {user.first_name}!")
        session.close()
        return ConversationHandler.END
    else:
        await update.message.reply_text("Привет! Давай зарегистрируемся.\nКак тебя зовут?")
        session.close()
        return ASK_NAME

async def ask_surname(update: Update, context: ContextTypes.DEFAULT_TYPE):
    context.user_data["first_name"] = update.message.text.strip()
    await update.message.reply_text("А теперь твоя фамилия:")
    return ASK_SURNAME

async def finish_registration(update: Update, context: ContextTypes.DEFAULT_TYPE):
    first_name = context.user_data["first_name"]
    last_name = update.message.text.strip()

    user_id = update.effective_user.id
    username = update.effective_user.username or ""

    session = SessionLocal()
    user = User(
        telegram_id=user_id,
        username=username,
        first_name=first_name,
        last_name=last_name,
        role=Role.EMPLOYEE,
    )
    session.add(user)
    session.commit()
    session.close()

    await update.message.reply_text(f"Отлично, {first_name}! Ты зарегистрирован как сотрудник.")
    return ConversationHandler.END


async def set_role(update: Update, context: ContextTypes.DEFAULT_TYPE):
    session = SessionLocal()
    args = context.args

    if len(args) != 2:
        await update.message.reply_text("Используй: /setrole username role\nПример: /setrole johndoe manager")
        return

    username, role_str = args
    role_str = role_str.lower()

    if role_str not in ("employee", "manager"):
        await update.message.reply_text("Роль должна быть 'employee' или 'manager'")
        return

    user = session.query(User).filter_by(username=username).first()

    if not user:
        await update.message.reply_text(f"Пользователь с username '{username}' не найден")
        session.close()
        return

    user.role = Role.MANAGER if role_str == "manager" else Role.EMPLOYEE
    session.commit()
    session.close()

    await update.message.reply_text(f"Роль пользователя {username} обновлена на {role_str}")




import re

async def forward_message(update: Update, context: ContextTypes.DEFAULT_TYPE):
    session = SessionLocal()
    sender_id = update.effective_user.id

    sender = session.query(User).filter_by(telegram_id=sender_id).first()

    if not sender or sender.role != Role.MANAGER:
        await update.message.reply_text("Только руководители могут пересылать сообщения сотрудникам.")
        session.close()
        return

    text = update.message.text.strip()

    # Пытаемся найти имя и фамилию в сообщении (первая пара слов с заглавной буквы)
    match = re.search(r"\b([А-ЯЁA-Z][а-яёa-z]+)\s+([А-ЯЁA-Z][а-яёa-z]+)\b", text)

    if not match:
        await update.message.reply_text("Не удалось распознать имя и фамилию в сообщении.")
        session.close()
        return

    first_name, last_name = match.groups()

    employee = (
        session.query(User)
        .filter_by(first_name=first_name, last_name=last_name, role=Role.EMPLOYEE)
        .first()
    )

    if not employee:
        await update.message.reply_text(f"Сотрудник {first_name} {last_name} не найден.")
        session.close()
        return

    try:
        await context.bot.send_message(
            chat_id=employee.telegram_id,
            text=f"Сообщение от руководителя:\n\n{update.message.text}",
        )
        await update.message.reply_text("Сообщение отправлено сотруднику.")
    except Exception as e:
        await update.message.reply_text("Ошибка при отправке сообщения сотруднику.")
        print(e)
    finally:
        session.close()
