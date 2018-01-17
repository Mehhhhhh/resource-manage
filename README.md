# resource-manage
Test for Feerik games

Le gestionnaire de ressource permet de télécharger les textures (.png) 
du jeu depuis un serveur HTTP/HTTPS. 

Il doit être capable d'enregistrer les textures sur le stockage du 
client (mobiles inclus) afin de pouvoir les recharger rapidement pour 
les prochains lancements de l'application 

Le chargement et l'enregistrement (pas le téléchargement) sur 
l'appareil sera multi-threadé dont le nombre de threads doit être 
paramétrable. 

Fonctionnement : 

Charger la texture en VRAM (classe Texture) si elle est stocké sur l'appareil 

Sinon, télécharger la texture, la stocker sur l'appareil et la charger en VRAM. 


En temps normal, les URLs sont envoyées par un serveur, pour le  test , 
le client connait déja les URLs des images. 


Language à utliser : C# UNITY3D 


Info : Le  test  sera executé sur une machine Windows avec Unity en 
platforme Android. 



Support du  test 

(GIT ou SVN) 


Un gestionnaire de version (GIT ou SVN) doit être utilisé. Le dépôt 
sera la première chose à mettre en place, elle permettra de voir la 
progression, c'est pourquoi il est préférable de commit/push dès que 
possible lorsque des nouvelles features sont ajoutées avec un 
commentaire (excepté lors d'oubli dans un commit précédent). 


Le dépôt sera construit de la manière suivante : 


Les sources du client Unity (Assets et ProjectSettings seulement, 
ignorer les autres dossiers et fichiers). 

Un document texte contenant les commentaires si il y en a ainsi que la 
version de unity utilisé. 


L'accès au dépôt sera transmise à Robin@Feerik.com. 

Si vous n'avez aucun moyen d'héberger un dépôt vous pouvez utiliser 
bitbucket (gratuit).
