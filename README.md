# Sistema de Cálculo de Seguro de Veículos


##  Implantação

O projeto foi implantado em servidores web tradicionais, utilizando IIS para hospedagem.
Também foi testado em ambiente Docker, rodando em um servidor Linux Debian 9 no modo autossuficiente (.NET self-contained).


## Funcionalidades Principais

- **API RESTful** para gerenciamento e cálculo de seguros.
- **Cálculo automático** do valor do seguro com base em fórmulas predefinidas.
- **Armazenamento de dados** em SQLite.
- **Relatório de médias** dos seguros em formato JSON.
- **Front-end web simples** para visualização do relatório.
- **Testes de unidade** abrangentes.

## Estrutura do Projeto

O projeto é dividido em duas partes principais:

```
./
├── backend/                 # Contém a API e a lógica de negócio (.NET Core 8.0)
├── frontend/                # Contém a aplicação web (HTML/CSS/JS servida por ASP.NET Core)
└── README.md                # Este arquivo
```

- A API estará disponível em:       `http://localhost:5000`
- A documentação Swagger estará em: `http://localhost:5000/swagger`
- O Front-end estará disponível em: `http://localhost:5001`

##  Exmplo envio seguro (teste pelo swagger)

### `POST /api/seguro`
Cria um novo seguro.

**Exemplo de Requisição:**
```json
{
  "veiculo": {
    "id": "9f8e7d6c-5b4a-3210-ffff-112233445566",
    "valor": 45000,
    "marcaModelo": "Honda Civic"
  },
  "segurado": {
    "id": "0a1b2c3d-4e5f-6789-abcd-998877665544",
    "nome": "Maria Silva",
    "cpf": "987.654.321-99",
    "idade": 42
  }
}
```


## Tecnologias Utilizadas

- **.NET 8.0**: Framework principal
- **ASP.NET Core**: Construção da API REST e serviço do front-end
- **Entity Framework Core**: ORM para interação com o banco de dados
- **SQLite**: Banco de dados leve e local
- **xUnit**: Framework de testes
- **Swagger**: Documentação interativa da API
- **HTML/CSS/JavaScript**: Desenvolvimento do front-end


