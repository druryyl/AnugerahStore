DELETE JenisBayar
GO

INSERT INTO JenisBayar 
VALUES ('KAS', 'Bayas Cash',0,1)
GO

INSERT INTO JenisBayar
VALUES('TR1','Transfer BCA',0,2)
GO

INSERT INTO JenisBayar
VALUES('TR2','Transfer BRI',0,3)
GO

INSERT INTO JenisBayar
VALUES('ED1','Mesin EDC BCA',1,4)
GO

INSERT INTO JenisBayar
VALUES ('ED2','Mesin EDC BRI',1,5)
GO

SELECT * FROM JenisBayar
