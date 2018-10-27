using LanguageExt.TypeClasses;

namespace Safety.Predicates
{
  public class NotNull<T> : Pred<T>
  {
    public bool True(T value) => value != null;
  }
}