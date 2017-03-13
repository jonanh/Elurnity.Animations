# Elurnity.Animations
Simple composable animation framework for Unity3D

# Objectives
- Provide a flexible and composable API.
- Provide serializable primitives.

# Why yet another animation framework?
- The unity animation framework is great and easy to use, but sometimes it feels frustrating because of two limitations:
  - The animators and the StateMachineBehaviours are stateless, forcing to split the state and the behaviour definition between the animator and the custom logic.
  - The new Playable API is almost all what we were dreaming for, but it doesn't play well with procedural animations on runtime.

  A very common task like this ends up being implemented by code:
  ```
    - if the mouse is pressed
       - Move object A to position B
       - Every 3 seconds
         - Make a pulse animation scaling a little bit A
    - if not pressed
       - Move object A to position C using a slastic tween
   ```
- Tweening libraries are easy to use for simple animations, but forces us to keep track a lot of mutable state.
   ```
   TweenAnimation tweenAnimation;
   
   void Animate()
   {
     var startPosition = A.transform.localPosition;
     var destPosition = Dest.transform.localPosition;
     tweenAnimation = Tween(progress => {
       A.transform.localPosition = Vector3.Lerp(startPosition, destPosition, prog) + CircularAnimation();
     });
   }
   
   void Stop()
   {
      tweenAnimation.Stop();
   }
   
   Vector2 CircularAnimation()
   {
      return new Vector2(Mathf.Cos(Time.time / frecuency) * amplitude, Mathf.Sin(Time.time / frecuency) * amplitude);
   }
   ```
    
# Design

### Animation

```
public abstract class Animation<P, S, T> : Node
    where P : Property<P>, new()
    where S : ISubject<P>
    where T : Transition
{
}
```

Modifies a **property** of a **subject** in a **transition** through time.

### Property

```
public interface Property<T>
{
    T Lerp(T src, T dst, float prog);
}
```

A property is something we know how to interpolate.

#### Properties

- **ColorProperty**
- **Vector2Property**
- **Vector3Property**
- **Vector4Property**
- **QuaternionProperty**
- **TransformProperty** composed of
  - Vector3 localPosition;
  - Vector3 localScale;
  - Quaternion localRotation
- **DelegatedProperty** 

For simplify implicit conversion operators are avaiable:
```
ColorProperty colorProperty = Color.red;
TransformProperty transformProperty = transform;
```

### Subject

```
public interface ISubject<P> where P : Property<P>
{
    void Apply(P state);
}
```
#### Subjects
- ***SubjectTransform***

A subject defines how a property is applied.

### Transition

```
public interface Transition : INode
{
    float Progress
    {
        get;
    }
}
```

A transition is something which progresses from 0 to 1. Not necesarily based on time, it can be based on our custom logic.

A transition can also be used as a node of a behaviour tree.

#### Transitions
- **TimeTransition**
- **TweenTransition**
- **AnimationCurveTransition** 
