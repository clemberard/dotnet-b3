# Documentation pour le système d'authentification

## Quelles sources ?

- https://learn.microsoft.com/fr-fr/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=net-cli#examine-register
- https://learn.microsoft.com/fr-fr/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=net-cli#log-in
- https://learn.microsoft.com/fr-fr/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=net-cli#log-out

## Comment ça marche ?

### Créer un utilisateur

Pour créer un utilisateur, il faut utiliser la classe `UserManager`.

```csharp
var user = new IdentityUser { UserName = "username" };
var result = await _userManager.CreateAsync(user, "password");
```

### Se connecter

Pour se connecter, il faut utiliser la classe `SignInManager`.

```csharp
var result = await _signInManager.PasswordSignInAsync("username", "password", false, false);
```

### Se déconnecter

Pour se déconnecter, il faut utiliser la classe `SignInManager`.

```csharp
await _signInManager.SignOutAsync();
```

### Vérifier si un utilisateur est connecté

Pour vérifier si un utilisateur est connecté, il faut utiliser la classe `SignInManager`.

```csharp
var result = _signInManager.IsSignedIn(User);
```

### Récupérer l'utilisateur connecté

Pour récupérer l'utilisateur connecté, il faut utiliser la classe `UserManager`.

```csharp
var user = await _userManager.GetUserAsync(User);
```
