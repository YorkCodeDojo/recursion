let rec factorial x = 
    match x with
    | 0 -> 1
    | _ -> factorial (x - 1) * x

let rec fibonacci f = 
    match f with
    | 1  | 2 -> 1
    | _ -> fibonacci (f - 1) + fibonacci (f - 2)


let rec sumList (l:List<int>) =
    match l with
    | [] -> 0
    | x::xs -> x + sumList xs


let rec countItems (l:List<int>) =
    match l with
    | [] -> 0
    | _::xs -> 1 + countItems xs

let rec reverseList (l:List<int>) =
    match l with
    | [] -> []
    | x::xs -> (reverseList xs) @ [x]
reverseList [1;2;3]

let l = [2;6;4;8;3;5;7;3;5]

// Find the largest entry in a list
let rec largestInList(l:List<int>)=
    match l with
    | [] -> 0
    | x::[] -> x
    | x::xs -> let largest = largestInList xs
               if x > largest then x else largest

// Find the smallest entry in a list
let rec smallestInList(l:List<int>)=
    match l with
    | [] -> 0
    | x::[] -> x
    | x::xs -> let smallest = largestInList xs
               if x < smallest then x else smallest

// Combine the largest and smallest functions
let rec inList l f =
    match l with
    | [] -> 0
    | x::[] -> x
    | x::xs -> let best = inList xs f
               if f x best then x else best

//let lessThan a b = a < b
//let moreThan a b = a > b

// Find the biggest of two positive integers,  using recursion,  but not the > operator
let biggest x y =
    let rec worker x y offset = 
        match x, y with
        | 0, _ -> y + offset
        | _, 0 -> x + offset
        | _ -> worker (x-1) (y-1) (offset+1)
    worker x y 0

biggest 9 4
biggest 4 9


let rec evensOnly (l:List<int>) =
    match l with
    | [] -> List.empty
    | x::xs when x % 2 = 0 -> x :: evensOnly xs
    | _::xs -> evensOnly xs


let rec isEven = function
    | 0 -> true
    | n -> isOdd (n - 1)
and isOdd = function
    | 0 -> false
    | n -> isEven (n - 1)


let rec ackermann m n =
    match m,n with
    | 0, _ -> n + 1
    | _, 0 -> ackermann (m-1) 1
    | _ -> ackermann (m-1) (ackermann m (n-1))


let rec directorySearch (fileName:string) folderName =
    let filesInFolder = System.IO.Directory.GetFiles(folderName)
    let foldersInFolder = System.IO.Directory.GetDirectories(folderName)
    let matchesInsubFolders = foldersInFolder |> Array.collect (directorySearch fileName) 

    if (filesInFolder |> Array.exists (fun x -> System.IO.Path.GetFileName(x).ToLower() = fileName.ToLower())) then
        Array.append [|folderName|] matchesInsubFolders
    else
        matchesInsubFolders


type Tree =
| Branch of string * Tree list
| Leaf of string

let tree = Branch ("a", [Branch ("b", [Leaf "c"; Leaf "d"]); Branch ("e", [Leaf "f"; Leaf "g"])])


let rec treeSearch (toFind:string) (tree:Tree) : bool =
    match tree with
    | Leaf(leaf) -> leaf = toFind
    | Branch(branch, children) -> if (branch = toFind) then
                                      true
                                  else
                                    children |> List.exists (treeSearch toFind)


//2.4
let countItemsAcc (l:List<int>) =
    let rec worker (l:List<int>) (acc:int) =
        match l.IsEmpty with
        | true -> acc
        | _ -> worker l.Tail (acc+1)
    worker l 0
            
let l2 = [1..999999]


//2.5
let rec evensOnlyAcc (l:List<int>) =
    let rec worker (l:List<int>) (acc:List<int>) =
        match l with
        | [] -> List.rev acc
        | x::xs when x % 2 = 0 -> worker xs (x::acc)
        | x::xs -> worker xs acc
    worker l List.Empty
    

//2.6 Continuations List Count
//Count the items in a list again, this time using continuations.
let rec countItemsCon f (l:List<int>)  =
    match l with
    | [] -> f 0
    | x::xs-> countItemsCon (fun x -> f(x + 1)) xs

countItemsCon (fun x -> x) [1..999999]

//2.7 Continuations Filter
//Filter a list of numbers again to get the evens, with a continuation.
let rec evensOnlyCon f (l:List<int>) =
    match l with
    | [] -> f []
    | x::xs when x % 2 = 0 -> evensOnlyCon (fun xs -> f(x::xs)) xs
    | _::xs -> evensOnlyCon (fun xs -> f(xs)) xs

evensOnlyCon (fun x -> x) [1..999999]



type BinaryTree<'a> =
| Branch of BinaryTree<'a> * BinaryTree<'a>
| Leaf of 'a

let rec inTree fn tree = 
    match tree with
    | Leaf(n) -> n
    | Branch(left,right) -> fn (inTree fn left) (inTree fn right)

let a = Leaf(1)
let b = Leaf(3)
let c = Branch(a,b)
let d = Leaf(5)
let e = Leaf(2)
let f = Branch(d,e)
let g = Branch(c,f)
let max a b = if a > b then a else b
inTree max g 

let exists a b = a || b



// 3 Advanced
// 3.1 Continuations Fibonacci
//Do Fibonacci again, this time with continuations to avoid a Stack Overflow.
//(Note: The 'standard' recursive solution is so slow you probably won't want to wait to find out if it's worked..)

let rec fibonacciCont f n = 
    match n with
    | 0 | 1 -> f 1
    | _ -> fibonacciCont (fun x -> f(fibonacciCont (fun b -> f (x+b)) (n - 2))) (n - 1) 
fibonacciCont (fun x -> x) 6



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code



