# StokEkstresi
Stok Ekstresi

> Stok listelemek için kullanılan Stored Procedure
```sql
CREATE OR Alter PROCEDURE StokListele @Malkodu varchar(30), @BaslangicTarihi int, @BitisTarihi int
AS
BEGIN
	Select 
		ROW_NUMBER() OVER(ORDER BY si.Tarih asc) AS SiraNo,
		CASE
			WHEN si.IslemTur = 0 THEN 'Giriþ'
			ELSE 'Çýkýþ'
		END AS IslemTur,
		si.EvrakNo,
		CONVERT(VARCHAR(15), CAST(si.Tarih - 2 AS datetime), 104) as Tarih,
		CASE
			WHEN si.IslemTur = 0 THEN CAST(si.Miktar as int)
			ELSE 0
		END AS GirisMiktar,
		CASE
			WHEN si.IslemTur = 1 THEN CAST(si.Miktar as int)
			ELSE 0
		END AS CikisMiktari,
		CAST(dbo.StokHesapla(ROW_NUMBER() OVER(ORDER BY si.Tarih asc), @Malkodu, @BaslangicTarihi, @BitisTarihi) as int) AS StokMiktar
	from STI si 
			where si.MalKodu = @Malkodu and si.Tarih between @BaslangicTarihi and @BitisTarihi
		Order by si.Tarih asc
END
```

> Stok hesaplamak için kullanılan Function
```sql
CREATE OR Alter FUNCTION dbo.StokHesapla (@SiraNo int, @Malkodu varchar(30), @BaslangicTarihi int, @BitisTarihi int)
RETURNS int
AS
BEGIN
	Declare @StokMiktari int = 0;/*Geriye dönecek stok miktarý*/

	/*Geçici tablo*/
	Declare @tempTable Table(RowNumber int, Miktar int, IslemTur smallint);

	/*Geçici tabloyu STI tablosu ile doldurup satýr sayýlarýný belirtiyoruz (satýr sayýsý önemli)*/
	insert into @tempTable
	SELECT 
		ROW_NUMBER() OVER (ORDER BY si.Tarih asc) AS RowNumber,
		si.Miktar, 
		si.IslemTur 
		FROM STI si 
		where si.MalKodu = @Malkodu and si.Tarih between @BaslangicTarihi and @BitisTarihi
		Order by si.Tarih asc

	/*Stok hesaplamak için kullanýlacak deðiþkenler*/
	Declare @Miktar int=0, @IslemTur smallint=0;

	/*Fonksiyona gönderilen sira numarasý miktarý kadar döngü kuruyoruz. Örn: sira no 2 geldi ise 1. ve 2. satýrý alacaðýz*/
	Declare @index int=1;
	while(@index<=@SiraNo)
	BEGIN

	/*Stok hesaplamak için kullanýlacak deðiþkenlerin içini dolduruyoruz*/
	Select @IslemTur = t.IslemTur, @Miktar=t.Miktar from @tempTable t where t.RowNumber=@index
	
	if(@IslemTur=0)/*Eðer giriþ varsa stok miktarýn üzerine ekle*/
		Set @StokMiktari = @StokMiktari + @Miktar
	Else/*Çýkýþ ise stoktan çýkar*/
		Set @StokMiktari = @StokMiktari - @Miktar

	Set @index = @index + 1;/*Döngü index ini artýr*/
	END

    RETURN(@StokMiktari);
END;
```

> Uygulamanın görünümü:
![App's view](https://github.com/FatihDumlupinar/StokEkstresi/blob/master/Dosyalar/1.png?raw=true)

> Arama yaptıktan sonra
![After searching](https://github.com/FatihDumlupinar/StokEkstresi/blob/master/Dosyalar/2.png?raw=true)

> Excel Çıktısı
![Excel Output](https://github.com/FatihDumlupinar/StokEkstresi/blob/master/Dosyalar/3.png?raw=true)

> Yazdır
![Print](https://github.com/FatihDumlupinar/StokEkstresi/blob/master/Dosyalar/4.png?raw=true)
