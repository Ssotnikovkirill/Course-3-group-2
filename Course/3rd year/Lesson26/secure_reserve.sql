BEGIN IMMEDIATE TRANSACTION;

-- Проверяем, свободно ли место
SELECT IsReserved FROM Seats WHERE SeatNumber = 'A2';

-- Если место занято, логируем неудачу и отменяем транзакцию
INSERT INTO ReservationAttempts (SeatID, CustomerName, Status)
SELECT SeatID, 'Jane Smith', 'FAILED' FROM Seats WHERE SeatNumber = 'A2' AND IsReserved = 1;

-- Если свободно, резервируем и логируем успех
UPDATE Seats SET IsReserved = 1 WHERE SeatNumber = 'A2' AND IsReserved = 0;

INSERT INTO Reservations (SeatID, CustomerName)
SELECT SeatID, 'Jane Smith' FROM Seats WHERE SeatNumber = 'A2' AND IsReserved = 0;

INSERT INTO ReservationAttempts (SeatID, CustomerName, Status)
SELECT SeatID, 'Jane Smith', 'SUCCESS' FROM Seats WHERE SeatNumber = 'A2' AND IsReserved = 1;

COMMIT;
