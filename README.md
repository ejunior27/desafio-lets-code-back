# Desafio Técnico - Backend

O propósito desse desafio é a criação de uma API que fará a persistência de dados de um quadro de kanban. Esse quadro possui listas, que contém cards.

## Rodando o Frontend

Um frontend de exemplo foi disponibilizado na pasta FRONT.

Para rodá-lo, faça:

```console
> cd FRONT
> yarn
> yarn start
```

## Configurando o Backemd

Para rodar o backend, deverá ser editado o arquivo appsettings.json, definindo os campos:

AppSettings.Secret: define a chave de criptografia para o token gerado no momento do login. Deve ser uma chave de 128bits.
AppSettings.Username: define o nome de usuário para teste.
AppSettings.Password: define a senha do usuário para teste.