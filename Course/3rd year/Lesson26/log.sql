CREATE TABLE ReservationAttempts (
    AttemptID INTEGER PRIMARY KEY AUTOINCREMENT,
    SeatID INTEGER,
    CustomerName TEXT NOT NULL,
    AttemptTime TEXT DEFAULT (DATETIME('now')),
    Status TEXT NOT NULL,
    FOREIGN KEY (SeatID) REFERENCES Seats(SeatID)
);
