from telegram import Update
from telegram.ext import ApplicationBuilder, CommandHandler, ContextTypes
from dotenv import load_dotenv
import os


from bot.database import init_db
from bot.handlers import set_role
from bot.handlers import forward_message


# Загружаем переменные
load_dotenv()
TOKEN = os.getenv("BOT_TOKEN")

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await update.message.reply_text("Привет! Добро пожаловать 👋")

async def ping(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await update.message.reply_text("pong!")
from telegram.ext import (
    ApplicationBuilder,
    CommandHandler,
    MessageHandler,
    ConversationHandler,
    ContextTypes,
    filters,
)
from dotenv import load_dotenv
import os

from bot.database import init_db
from bot.handlers import start, ask_surname, finish_registration, ASK_NAME, ASK_SURNAME

load_dotenv()
TOKEN = os.getenv("BOT_TOKEN")

def main():
    init_db()
    app = ApplicationBuilder().token(TOKEN).build()

    conv_handler = ConversationHandler(
        entry_points=[CommandHandler("start", start)],
        states={
            ASK_NAME: [MessageHandler(filters.TEXT & ~filters.COMMAND, ask_surname)],
            ASK_SURNAME: [MessageHandler(filters.TEXT & ~filters.COMMAND, finish_registration)],
        },
        fallbacks=[],
    )

    app.add_handler(conv_handler)

    app.add_handler(CommandHandler("setrole", set_role))

    print("Бот запущен...")
    app.add_handler(MessageHandler(filters.TEXT & ~filters.COMMAND, forward_message))
    app.run_polling()

if __name__ == "__main__":
    main()

