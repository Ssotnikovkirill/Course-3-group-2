BEGIN TRANSACTION;

-- Проверяем, свободно ли место (например, A1)
SELECT IsReserved FROM Seats WHERE SeatNumber = 'A1';

-- Если свободно, резервируем
UPDATE Seats SET IsReserved = 1 WHERE SeatNumber = 'A1';

-- Добавляем запись о резервировании
INSERT INTO Reservations (SeatID, CustomerName)
SELECT SeatID, 'John Doe' FROM Seats WHERE SeatNumber = 'A1';

COMMIT;
