using LanguageExt.TypeClasses;
using System;

namespace Safety.Predicates
{
  public class NonEmptyString : Pred<string>
  {
    public bool True(string value) => value == null || value.Trim() != String.Empty;
  }
}