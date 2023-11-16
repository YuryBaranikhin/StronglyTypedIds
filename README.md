![.NET](https://github.com/YuryBaranikhin/StronglyTypedIds/workflows/.NET/badge.svg)

# StronglyTypedIds

StronglyTypedIds помогает типизировать идентификаторы сущностей для проверки на этапе компиляции.

## Какую проблему решаем?

Довольно часто в качестве идентификаторов сущностей предметной области выступают Guid, int, long или string.
Идентификаторы могут быть переданы в качестве аргументов:

```
void AssignContractResponsible(Guid contractId, Guid employeeId);
```

В данном примере используется 2 идентификатора. Определить, где из них какой, можно только по имени аргумента. Однажды
можно ошибиться и передать идентификаторы не в том порядке. Проблема усугубляется, если в предметной области есть
сущности с похожим названием:

```
Contract и Contractor
Order и OrderTemplate
PriceList и PricePosition
```

Другой пример:

```
IDictionary<Guid, Contract> GetContractsByClients(IEnumerable<Guid> clientIds);
```

В данном случае в качестве ключа словаря, вероятно, будет выступать идентификатор клиента. Но мы не можем знать этого
наверняка, если не посмотрим реализацию.

## Решение

В качестве решения предлагается передавать не только значение идентификатора, но и тип идентифицируемой сущности.

Так вместо:

```
void AssignContractResponsible(Guid contractId, Guid employeeId);
```

Получается:

```
void AssignContractResponsible(GuidFor<Contract> contractId, GuidFor<Person> employeeId);
```

А вместо:

```
IDictionary<Guid, Contract> GetContractsByClients(IEnumerable<Guid> clientIds);
```

Будет:

```
IDictionary<GuidFor<Client>, Contract> GetContractsByClients(IEnumerable<GuidFor<Client>> clientIds);
```

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
