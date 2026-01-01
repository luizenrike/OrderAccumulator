## Descrição:

Serviço para processamento de ordens, simulando uma exposição máxima (absoluta) de R$ 1.000.000,00 por ativo.

Endpoint disponível em: https://orderaccumulator.onrender.com/api/orderaccumulator/new-order

- Sem utilização de métodos assincronos;
- Única camada, por se tratar de uma API com um único método;
- Utilização de uma sessão crítica para cada Asset, com o objetivo de controlar a concorrência

### Exemplo de requisição: 

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

