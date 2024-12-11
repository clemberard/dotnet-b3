# dotnet-b3

## Commandes .NET basiques

### Créer un projet
```bash
dotnet % dotnet new mvc -n mvc -o mvcTemplate
```

###  Créer un projet avec une solution
```bash
dotnet build
```

### Lancement du projet
```bash
dotnet run
``` 

Cette commande compile et lance le projet

## Définitions

### Espace de nom (namespace)

Un espace de nom est un moyen de regrouper des classes, des structures, des interfaces, des délégués et d'autres espaces de noms dans une hiérarchie logique, structurée et hiérarchique.

Permet de faciliter l'import/export du code source.

## Methodes des controllers

Les méthodes des controllers sont des actions qui sont appelées par les routes.

## Interface

Une interface est accessible publiquement.

## DB

### Commande pour les migrations
```bash
dotnet ef migrations add InitialCreate
```

### Commande pour mettre à jour la base de données
```bash
dotnet ef database update
```