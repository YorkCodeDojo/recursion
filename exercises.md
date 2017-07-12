Recursion Exercises
===================

Write recursive functions to do all of the following.  For extra bonus points, do it without mutable variables. Remember no loops are allowed.

Work on whichever problems you like in any order.

### Credits
Most of the content is from the slides prepared by Grant for Leeds Code Dojo.


## 1 Basic

### 1.1 Factorial

Write a recursive function which calculates the factorial of a number, defined as:

![factorial](http://upload.wikimedia.org/math/a/9/1/a91da51a80ac8291d8dbcc4cb77c0936.png)

5! = 120

### 1.2 Fibonacci

Calculate the Nth Fibonacci number:

![fibonacci](http://upload.wikimedia.org/math/7/2/7/727f7c8fa1794d5d2d5ad828adb829c8.png)

with the first two numbers in the sequence being

![fibonacci](http://upload.wikimedia.org/math/4/3/d/43d30dc03ffec0a82d4471f1009ef519.png)

The start of the sequence goes:

![fib](http://upload.wikimedia.org/math/c/a/b/cabe91689f6a1af616ace02827c6e89c.png)



## 2 Lists

For this section you need a data structure which allows you to split up a list into it's HEAD and TAIL.
For example the list a;b;c;d  has a head of 'a' and a tail of 'b;c;d'

* In F# this is written as x::xs
* In NodeJS this is written as [head, ...tail]
* In C# you will need to write your own list class,  see Appendix 2

### 2.1 Sum a list

Sum the values in a list.

The sum of [1, 2, 3, 4, 5] is 15.

### 2.2 Count the items in a list

There are 5 items in the list [1, 2, 3, 4, 5].

Can you combine answers for exercises 1.3 and 1.4 into a single generic solution?

### 2.3 Filter a list

Filter a list of numbers to return only the even ones.

The list [1, 2, 3, 4, 5, 6, 7, 8] when filtered should give [2, 4, 6, 8].

Is this solution generic?


## 3. Harder

### 3.1 Mutual Recursion
 
Write the pair of functions isEven and isOdd using Mutual Recursion.  The pseudocode for this is:

    isEven(n)
      if n is 0 then true
      else isOdd(n - 1)

    isOdd(n)
      if n is 0 then false
      else isEven(n - 1) 

### 3.1 Ackermann

Write the Ackermann function, defined for today's purposes as:

![ack](http://upload.wikimedia.org/math/0/a/e/0ae4053de098cc9554752b190a38bc56.png)

When called with the numbers 3 and 10, it should return 8189.  Enter much higher numbers and you could be waiting a while.



## 4 Trees

### 4.1 Directory Search

Write a function which searches all files and folders of a provided path for a file with a particular name.

If your language makes this difficult, move onto the next exercise, which is similar. 

### 4.2 Tree Search

Write a function which searches a tree-like data structure for a given item.

If your language supports a recursive list structure, this will do, as the head and tail can be considered the two branches of the tree, e.g. Scheme:

    (treesearch 9 '(((9)) 2 (3) (4 5 (6 (7)) 8)))

Alternatively you could write yourself some kind of tree structure and use that:

    type Tree =
    | Branch of string * Tree list
    | Leaf of string
    
    let tree = Branch ("a", [Branch ("b", [Leaf "c"; Leaf "d"]); Branch ("e", [Leaf "f"; Leaf "g"])])

If that all seems like too much work in your language, just move along.  

### 4.3 Binary Search

Write a function which searches a binary tree in order to find the largest value held in a leaf node.  (5 in the example below)

                             /\
                           /\ /\
                          1 3 5 2

Write a function which searches a binary tree in order to find the smallest value held in a leaf node.

Can you combine the two into a single generic function?


### 5. Avoiding Stack Overflow

### 5.1 Tail Call List Count

Try counting the items in a list again, using your previous solution (if you wrote one), but in a list containing 100,000 items.

A couple of things might happen:
1. It will be extremely slow.  This is especially likely if you're using something like C# which doesn't have a recursive data type.  

2. You might get a Stack Overflow.  (Some languages, in particula dynamic ones, don't seem to have this problem regardless).

Write the function again, this time with a tail call (e.g. using an accumulator to hold the count).  Assuming your language supports TCO, you should be able to count on the list with 100,000 items.  

### 5.2 Tail Call Filter

Try filtering a list with 100,000 items.  Again, this might be slow and you might get a Stack Overflow.

Write a function to filter the list of numbers to get the evens, this time with a tail call.

### 5.3 Continuations List Count

Count the items in a list again, this time using continuations.

### 5.4 Continuations Filter

Filter a list of numbers again to get the evens, with a continuation.

## 6 Advanced

### 6.1 Continuations Fibonacci

Do Fibonacci again, this time with continuations to avoid a Stack Overflow.

(Note: The 'standard' recursive solution is so slow you probably won't want to wait to find out if it's worked..)

### 6.2 Continuations Tree Search

Implement either the 'Directory search' or 'Tree Seach' again, this time with continuations so large structures can be searched.  Try creating a large structure to test it with.

### 6.3 Continuations Ackermann

Ackermann, with continuations.  Try calling it with 3 and 12 to see if it's worked.

### 6.4 Towers of Hannoi

Go and solve the [Towers of Hannoi puzzle](https://www.learneroo.com/modules/71/nodes/402) using recursion.

### 6.5 Permutations

Output all permutations of a passed string (or list of characters).

### Appendix A - Optimising Tail Calls in C#

While the .Net VM and C# compiler are able to optimise tail calls (to avoid Stack Overflow), it may or may not happen.  To get your tail calls optimised, make sure you:
* Compile for 64-bit (in project build settings) - 32-bit applications don't get TCO
* Turn on 'Optimize code' (in project build settings)
* Use a more recent version (apparently the optimisation is more likely on .Net 4 and above)

### Appendix B - Tips for working with lists in C# and similar languages.

If your language doesn't have a recursive list structure, doing recursion with collections can be a pain.  Some of the problems with the built-in list structures are:
* they don't always make it easy to get the 'head' and 'tail' of a list
* Building up a list by appending items onto the front can be difficult
* Both of the above can be very inefficient

With C#, The best way is to define your own recursive data type, which might look a bit like this:

    public class RecursiveList {

        private readonly int? _head;
        private readonly RecursiveList _tail;

        private RecursiveList(int? head, RecursiveList tail) {
            _head = head;
            _tail = tail;
        }

        public int Head { get {
            if (this.IsEmpty)
                throw new InvalidOperationException("Cannot read Head of an empty list");

            return _head.Value; 
        } }

        public RecursiveList Tail { get { return _tail; } }
        public bool IsEmpty { get { return !_head.HasValue; } }

        public static RecursiveList Cons(int head, RecursiveList tail) {
            return new RecursiveList(head, tail);
        }

        public static RecursiveList Empty() {
            return new RecursiveList(null, null);
        }

    }

Filling it up, printing it and/or comparing it to other things will be your main challenges, but it is efficient and works well with recursion.
