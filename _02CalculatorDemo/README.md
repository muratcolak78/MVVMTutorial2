# Content und DataContext
## Content
+ **Wie** wird es dargestellt? (Layout, Ressourcen, Styles, Animationen usw.)
## DataContext
+ **Was** wird dargestellt? Daten!
++ ***DataBinding***: Target/Ziel (UI-Element)  - Datenquelle (public Properties)
+++ Implementiere Schnittstelle **INotifyPropertyChanged** um das Target über eine Datenquelländerung zu benachrichtigen 
++++ Löse dabei das PropertyChanged-Event aus (mit Namen der Property)


## Anschlussprojekt: Grundlagen des DataBindings
+ Ziel des Projekts ist es, dass Zustandsänderungen im Modell automatisch in der UI reflektiert werden.
+ Als Modell der Datenquelle soll eine Klasse Product dienen. Das grobe Schema liegt in einem Klassendiagramm vor:

+---------------------+
|       Product       |
+---------------------+
| - name: string      |
| - price: double     |
| - category: string  |
| - image: string     |
| - description: string
+---------------------+
| + Name: string      |
| + Price: double     |
| + Category: string  |
| + Image: string     |
| + Description: string
+---------------------+

+ Erstelle ein Benutzeroberflächenlayout in XAML.
+ Implementiere das DataBinding zwischen dem Produktmodell und der Benutzeroberfläche.
