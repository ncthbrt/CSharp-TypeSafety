using LanguageExt.TypeClasses;
using System;
using System.Linq;

namespace Safety.Predicates
{
  public class NumericString : Pred<string>
  {
    public bool True(string value) => !String.IsNullOrWhiteSpace(value) && value.All(x => Char.IsDigit(x));
  }
}