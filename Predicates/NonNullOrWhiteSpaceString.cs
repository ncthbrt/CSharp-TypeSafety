using LanguageExt.TypeClasses;
using System;

namespace Safety.Predicates
{
  public class NonNullOrWhiteSpaceString : Pred<string>
  {
    public bool True(string value) => !String.IsNullOrWhiteSpace(value);
  }

  public class IsCurrencyCode : Pred<string>
  {
    public bool True(string value) => value.Length == 3;
  }
}