using UnityEngine;

// Predicate --> Function that tests a condition and the return a boolean value Ex: Is the enemy defeated? Is the palyer jumping?
public interface IPredicate
{
    bool Evaluate();

}
