# ASP.NET Core 10 Validation

This repository is a sample project demonstrating the differences 
in validation support between ASP.NET Core 10 Minimal APIs, 
Immediate.Apis with [.NET 10 built-in validation](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-10.0?view=aspnetcore-10.0#validation-support-in-minimal-apis),
and Immediate.Apis with Immediate.Validations.

The solution uses [Scalar](https://scalar.com/) to visualise the
OpenAPI documentation for each approach.

There are 3 `.http` files which include tests to demonstrate
the validation behavior of each approach.

Below is a summary of the validation capabilities of each approach.

### Minimal APIs
 
- ✅ Correctly returns 400 Bad Request in all cases.
- ✅ OpenAPI support.

### Immediate.Apis

- ❌ Does not return 400 Bad Request in **any** cases.
- ✅ OpenAPI support.

### Immediate.Apis with Immediate.Validations

- ⚠️ Correctly returns 400 Bad Request in **most** (not all) cases.
- ❌ Does not return 400 Bad Request when using `[AsParameters]`.
- ❌ No OpenAPI support.