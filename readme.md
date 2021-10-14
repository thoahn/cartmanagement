- uygulama docker container üzerinde koşacak şekilde ayağa kaldırılacağı için, bilgisayarınızda yüklü olmalıdır.
(docker download linki : https://desktop.docker.com/win/stable/amd64/Docker%20Desktop%20Installer.exe)

- Dockerfile dosyasının bulunduğu dizinde powershell, cmd ya da vs code terminal açınız.

- image oluşturmak için bu komutu çalıştırınız =====> docker build --no-cache -t cartmanagement:v1 .

- bu image'dan container oluşturmak için bu komutu çalıştırınız =======> docker run -d --name cartmanagementcon -p 5000:4500 cartmanagement:v1

- ürün eklemek için http://localhost:5000/api/cart/addtocart linkini kullanabilirsiniz.

- kontrol amaçlı kullanılabilecek API linkleri :
	=> http://localhost:5000/api/cart/all
	=> http://localhost:5000/api/products/all
	=> http://localhost:5000/api/persons/all
	=> http://localhost:5000/api/categories/all
	

#Developer Notu :
	- uygulamanın linux container üzerinde koşturulması tavsiye edilir.
	- mongoDB'yi container üzerinde koşturmak için uğraşıldı fakat policy sorunları nedeniyle localdb (SQLite) kullanıldı.