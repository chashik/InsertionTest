### Test
- Simple comparison of SqlBulkCopy, SQLClient and some ORMs (EF6, EF Core, Linq2Sql) in data insertion time on given model: 1 class -> 1 table.
- ConsoleApp project for .Net Framework 4.5.2, NetCore - for .Net Core 2.1.
#### Builder pattern
- Comparison project:  Provider abstract class implements IProvider with variable insertion scenarios as an abstract builder and Test class as a director. 
- Concrete builders are in ORMFree, EF6, Linq2SQL and NetCore projects.
