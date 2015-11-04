# OKE-Project

Zrobienie całości zajęło mi około 2,5h. W projekcie mogły pozostać niepotrzebne pliki z templatu MVC.

Najważniejsze wady w projekcie spowodowane limitem czasu na zadanie to brak walidacj wprowadzonych danych, brak zabezpieczenia pliku xml przed równoczesnym zapisem przez różne osoby, brak sekcji try, catch i obsługi wyjątków przy wrażliwych na wyjątki miejscach takich jak odczyt z pliku oraz być może nieco nieoptymalny sposób zapisu danych poprzez serializacje całej kolekcji krajów zamiast dopisywania pojedynczych elementów. Oczywiście widoki/css też mogły by być dużo lepsze :)

W przypadku zmiany formatu krajów w pliku xml, dzięki klasie XmlSerializer wystarczy zmienić model Country tak aby odzwierciedlał obecny format danych i oczywiście zrobić poprawki w widokach. Reszta powinna działać po staremu.

## Poprawki (Mam nadzieje, że wsyatrczy)

###Rzeczy dodane:
- Walidacja danych wejściowych .
  - Obowiązkowe pola z nazwą i stolicą.
  - Nazwy krajów nie mogą się powtarzać.
  - Powierzchnia i populacja nie mogą być ujemne.
- Obsługa wyjątków w przypadku zapisywania i odczytywania danych.
- logowanie wyjątków za pomocą log4net.
- Zapobieganie równoczesnemu zapisowi przez wielu użytkowników danych do pliku xml. (Pozwoliłem sobie zostawić fragmenty kodu którymi sprawdzałem czy to faktycznie działa.) 
- Mała poprawka widoku częściowego z detalami.

```CSharp
{
            Countries.CountriesList.Add(country);
            //DataContext.SaveDatabase(Countries);
            Task.Run(() => DataContext.SaveDatabase(Countries));
            Task.Run(() => DataContext.SaveDatabase(Countries));
            Task.Run(() => DataContext.SaveDatabase(Countries));
            Task.Run(() => DataContext.SaveDatabase(Countries));
            Task.Run(() => DataContext.SaveDatabase(Countries));
            Task.Run(() => DataContext.SaveDatabase(Countries));
}

```

###Rzeczy niezrobione (chciałem oddać jeszcze dziś przed 22.00):
- Dopisywanie pojedynczych rekordów do pliku xml zamiast serializacji całej kolekcji.
- więcej poprawek w wyglądzie widoków i css.

