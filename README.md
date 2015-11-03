# OKE-Project

Zrobienie całości zajęło mi około 2,5h. W projekcie mogły pozostać niepotrzebne pliki z templatu MVC.

Najważniejsze wady w projekcie spowodowane limitem czasu na zadanie to brak walidacj wprowadzonych danych, brak zabezpieczenia pliku xml przed równoczesnym zapisem przez różne osoby, brak sekcji try, catch i obsługi wyjątków przy wrażliwych na wyjątki miejscach takich jak odczyt z pliku oraz być może nieco nieoptymalny sposób zapisu danych poprzez serializacje całej kolekcji krajów zamiast dopisywania pojedynczych elementów.

W przypadku zmiany formatu krajów w pliku xml, dzięki klasie XmlSerializer wystarczy zmienić model Country tak aby odzwierciedlał obecny format danych i oczywiście zrobić poprawki w widokach. Reszta powinna działać po staremu.

