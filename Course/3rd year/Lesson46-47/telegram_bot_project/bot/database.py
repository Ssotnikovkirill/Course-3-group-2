from sqlalchemy import create_engine, Column, Integer, String, Enum
from sqlalchemy.orm import declarative_base, sessionmaker
from dotenv import load_dotenv
import os
import enum

from sqlalchemy import BigInteger

# Загружаем .env
load_dotenv()

# Получаем URL базы
DATABASE_URL = os.getenv("DATABASE_URL")

# SQLAlchemy настройки
engine = create_engine(DATABASE_URL)
SessionLocal = sessionmaker(bind=engine)

Base = declarative_base()

# Роли
class Role(enum.Enum):
    EMPLOYEE = "employee"
    MANAGER = "manager"

# Модель пользователя
class User(Base):
    __tablename__ = "users"

    id = Column(Integer, primary_key=True)
    telegram_id = Column(BigInteger, unique=True, nullable=False)
    username = Column(String, unique=True, nullable=True)
    first_name = Column(String, nullable=False)
    last_name = Column(String, nullable=False)
    role = Column(Enum(Role), nullable=False)

# Функция создания таблиц
def init_db():
    Base.metadata.create_all(bind=engine)
