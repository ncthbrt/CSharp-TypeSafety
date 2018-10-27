using LanguageExt.TypeClasses;
using System;

namespace Safety.Predicates
{
  public class GreaterThanZero<T> : Pred<T>
      where T : IComparable<T>
  {
    public bool True(T value) => value.CompareTo(default(T)) > 0;
  }
}