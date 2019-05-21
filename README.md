# Introduction 
Nexio Challenge

<b>Scénario</b>: Un client vous demande de créer un prototype de produit pour démontrer ce qui est possible au point de vue fonctionnel. Comme il ne connaît rien à la programmation, il va faire appel à un architecte-consultant qui est connu comme étant strict quand il s’agit d’évaluer la qualité logicielle.

L’architecte a établi une liste de requis pour votre prototype:

Produire un API REST qui permet de:
•	Afficher un catalogue de produits
•	Afficher le détail d’un produit
•	Ajouter un produit au panier
•	Enlever un produit du panier
•	Afficher le contenu du panier

L’architecte mentionne qu’il serait bien si le prototype pouvait aussi inclure un UI en WPF (bonus). 

<b>Contraintes</b>:
•	Utiliser une base de données fichier ou NoSQL tel que CosmosDB
•	Ajoutez un mécanisme pour offrir des promotions. Il y aura deux types de promotions possible au départ (la nature de ces promotions est laissé à votre discrétion), mais un nouveau type de promotion devrait pouvoir être ajoutée simplement en créant une nouvelle classe dans le code.
•	N’utilisez pas de framework tel que Unity. Ceci ne devrait pas être considéré comme allant à l’encontre des critères d’évaluation.

<b>Évaluation</b>

Vous serez évalué sur les points suivants:
•	Connaissance générale du contexte web et du framework .Net
•	Architecture et utilisation de patrons de conception
•	Qualité du code
o	Test unitaires / Intégration
o	Métriques du code (couplage bas, complexité cyclomatique)
o	Application des principes SOLID
o	Code commenté et auto-documenté
•	Respect de l’énoncé

<b>Pour la remise</b>:
•	Important le faire dans un délai raisonnable. 
•	Vous avez droit à l’internet pour référence bien sûr, mais toute copie d’un tutoriel sera rapidement détecté et vous éliminera du processus.
•	Un lien à un repo Github suffit comme soumission.


# Getting Started
If you download this code to run locally, have <b>MongoDB</b> installed and running on localhost on default ports.

# Build and Test
Just run the tests using Visual Studio. 

# API Documentation
Everything is documented using Swagger