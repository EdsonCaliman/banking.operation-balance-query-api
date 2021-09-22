# banking.operation-balance-query-api

Banking Operation Solution - Balance Query Api

[![.NET](https://github.com/EdsonCaliman/banking.operation-balance-query-api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/EdsonCaliman/banking.operation-balance-query-api/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/EdsonCaliman/banking.operation-balance-query-api/badge.svg?branch=main)](https://coveralls.io/github/EdsonCaliman/banking.operation-balance-query-api?branch=main)

This project is a part of a Banking Operation solution, with DDD and microservices architecture, using .Net Core.

![BankingOperations (1)](https://user-images.githubusercontent.com/19686147/133843637-85277ee1-9748-4456-befa-4b2265e3ebec.jpg)

Using a docker-compose configuration the components will be connected so that together they work as a solution.

This component will be responsible for returning a client's balance. It uses a mysql transactions database to get the data.



# Bussiness Rules



# How to run

With a docker already installed:

Run first the project: https://github.com/EdsonCaliman/banking.operation-transaction-api

After run:

docker-compose up -d

For swagger open the URL: http://localhost:8003/swagger