Merhaba,

Bu projede veritabanı olarak MongoDb kullanıldı, ayrıca sweet alert ve viewcomponentslere de yer verildi.

<h1>★ MongoDb Nedir? ★ </h1>
📌 MongoDB; açık kaynak, NoSQL veritabanı uygulamasıdır. <br><br>
📌 MongoDB, verileri JSON benzeri bir veri biçimi olan BSON tabanlı dokümanlarda saklamaktadır<br><br>

★  MongoDb NoSQL bir veri tabanıdır yani ilişkili tablo yapısı buludurmayan bir veritabanıdır.<br>

Peki ilişki bulunduraıyorsak ne yapacağız ? <br>
Örneği proje içinde yazmış olduğum entitylerden vereceğim.<br>

<hr>

 📌 İlk önce ilişki kuracağımız entitylerimizi oluşturmalıyız.

Ürün Tablosu
 
![product](https://github.com/user-attachments/assets/7e668a31-1f94-43b5-bf6e-1c3917ff4072)

Burada Category türünde bir category propertiysi ve ardından string türde categoryId tanimliyoruz. category propertysinin üstünde bulunan [BsonIgnore] ifadesi, bu propertinin veri tabanına yansıtılmıyacağını göstermektedir.<br>

Şimdi Category Tablosuna Bakalım.

![category](https://github.com/user-attachments/assets/abf30581-3256-4925-bd30-abf34498286e)

burada ilişkinin 2. adımı olarak liste türünde product yani ürünler tablosunu veriyoruz aynı şekilde buraya da bsonIgnore yazıyor ve bu propertyinin MongoDb'ye yansımasını engelliyoruz<br>

Entityler tamam, sırada dtolarımız var.

![image](https://github.com/user-attachments/assets/0a423dbd-e0f6-4e7c-8900-763e362aef0e)

burada entity den farklı olarak resultcategoryDto türünde bir category aliyoruz (category propertyleri aynı)<br>

ve geldik Kod kısmına

![Code](https://github.com/user-attachments/assets/c8130dc7-481f-45c7-9ef1-e209e8d4a9c7)

📌 İlk aşama olarak ürünlerimizin listesini çekiyoruz.<br>
📌 daha sonra geriye döndürmek istediğimiz dto türünün bir liste örneğini alıyoruz.<br>
📌 sonraki aşamada ise ilk aşamada tutuğumuz verilerde foreach ile dönüyoruz<br>
📌 category tablosunda item yani foreach içinde dönen veriden categoryIdsini ürünler tablosunda buluyoruz.<br>
📌 bulduğumuz değer bize category olarak dönecektir biz entityler yerine dtolar ile çalıştığımız için burada AutoMapper ile mappleme yapıyoruz.<br>
📌 ardından en başta oluşturulan liste örneğinin elamanlarına döngüden gelen verileri ve maplediğimiz category verisini ekleme yapyoruz<br>
📌 son aşamada örneği geriye döndürüyoruz ve işlemi tamamlıyoruz.<br>

Not: automapper ile eşlediğimiz dtoyu mapping'de geçmeyi unutmamalıyız.<br>

MongoDb kullanırken, ilişkili tablolarınızı bu şekilde kullanabilirsiniz.
<br>
<h1>Admin Dashboard Alanı</h1>

![admin01](https://github.com/user-attachments/assets/c72e8e4b-abce-410b-9bcd-e1b8a839ec05)

<hr>

📌 Bu alanda son 10 rezervasyon listesi, site içi verilerin sayıları ve pahalı ve ucuz ürünün adı listeleniyor.

![admin02](https://github.com/user-attachments/assets/b14b3b9e-77bc-4a13-b7b7-41f18d807366)

📌 Bu alan ürünlerin yer listelendiği yerdir.

![admin03](https://github.com/user-attachments/assets/38fef3b2-4222-4f47-a73f-64e1e416e488)

📌 Rezervasyonların listelendiği alandır.<br>
📌 Burada admin rezervasyon iptal edebilir onaylayabilir veya bekletebilir. ayrı zamanda silme güncelleme ve ekleme de yapabilir.<br>
📌 kayıtlar arasında ad soyad'a göre arama işlemi gerçekleştirilebilmektedir.


![image01](https://github.com/user-attachments/assets/82bf2241-7aa9-456e-a832-c12a4f4b9214)

📌 Ana Sayfa öne çıkanlar alanı

![image02](https://github.com/user-attachments/assets/ea2fb549-05af-4f3a-99b2-626435a7c504)

📌 Ana Sayfa hakkımızda alanı

![image06](https://github.com/user-attachments/assets/0f557259-eda0-4f63-a997-375a3bbb9c47)

📌 Ana Sayfa ürünler alanı

![image07](https://github.com/user-attachments/assets/b383d62a-caf5-4961-85b9-ec6493c091fd)

📌 Ana Sayfa rezervasyon yapma alanı

![image](https://github.com/user-attachments/assets/aadb1f82-0813-4169-92b8-019ba837d28b)

📌 menüler sayfasında menü listesi.



