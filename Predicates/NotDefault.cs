using LanguageExt.TypeClasses;

namespace Safety.Predicates
{
  public class NotDefault<T> : Pred<T>
  {
    public bool True(T value) => !default(T).Equals(value);
  }
}