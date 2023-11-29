![.NET](https://github.com/YuryBaranikhin/StronglyTypedIds/workflows/.NET/badge.svg)

# StronglyTypedIds

StronglyTypedIds helps to type entity identifiers for compile-time checking.

## What problem are we solving?

Quite often, Guid, int, long, or string are used as identifiers for domain entities.
Identifiers can be passed as arguments:

```
void AssignContractResponsible(Guid contractId, Guid employeeId);
```

In this example, 2 identifiers are used. You can only determine which one is which by the name of the argument. One day
you can make a mistake and pass the identifiers in the wrong order. The problem is exacerbated if there are
entities with similar names in the domain:

```
Contract и Contractor
Order и OrderTemplate
PriceList и PricePosition
```

Another example:

```
IDictionary<Guid, Contract> GetContractsByClients(IEnumerable<Guid> clientIds);
```

In this case, the client's identifier will probably act as the key of the dictionary. But we can't know this
for sure, unless we look at the implementation.

## Solution

The proposed solution is to pass not only the value of the identifier, but also the type of the identifiable entity.

So instead of:

```
void AssignContractResponsible(Guid contractId, Guid employeeId);
```

It becomes:

```
void AssignContractResponsible(GuidFor<Contract> contractId, GuidFor<Person> employeeId);
```

And instead of:

```
IDictionary<Guid, Contract> GetContractsByClients(IEnumerable<Guid> clientIds);
```

It will be:

```
IDictionary<GuidFor<Client>, Contract> GetContractsByClients(IEnumerable<GuidFor<Client>> clientIds);
```

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


## Support

If you find StronglyTypedIds helpful and would like to support my work, consider [buying me a coffee](https://www.buymeacoffee.com/yurybaranikhin). Thank you for your support!

