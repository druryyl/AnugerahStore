DELETE BrgStokHarga

INSERT INTO BrgStokHarga
	SELECT BrgID, Sum(QtySisa), 0
	FROM BPStok
	GROUP BY BrgID

UPDATE BrgStokHarga
SET Harga = bb.harga
FROM BrgStokHarga aa
INNER JOIN(
	SELECT BrgID, Harga
		FROM BrgPrice
		WHERE Qty <=1
	) bb ON aa.BrgID = bb.BrgID

INSERT INTO BrgStokHarga
	SELECT BrgID, 0, Harga
	FROM BrgPrice
	WHERE BrgID NOT IN (Select BrgID FROM BrgStokHarga)
		AND Qty <= 1

