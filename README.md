## Descrição:

Serviço para processamento de ordens, simulando uma exposição máxima (absoluta) de R$ 1.000.000,00 por ativo.

Endpoint disponível em: https://orderaccumulator.onrender.com/api/orderaccumulator/new-order

- Única camada, por se tratar de uma API com um único endpoint;
- Utilização de uma sessão crítica para cada Asset, com o objetivo de controlar a concorrência

## Execução:

Clonar o projeto e buildar, após isso, realizar uma requisição via swagger ou via postman.

### Exemplo de requisição (POST) no endpoint /api/orderaccumulator/new-order: 

```
    {
      "ativo": "PETR4",
      "lado": "C",
      "quantidade": 100,
      "preco": 32.50
    }
```

### Exemplo de resposta:

```
    {
      "sucesso": true|false,
      "exposicao_atual": 12345.67,
      "msg": "Processada com sucesso | Exposicao financeira atingida",  
    }
```

