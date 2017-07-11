// 1.1 factorial
exports.factorial = function (n) {
    if (n == 0) {
        return 1;
    }
    else {
        return exports.factorial(n - 1) * n;
    }
}

// 1.2 fibonacci
exports.fibonacci = function (n) {
    switch (n) {
        case 1:
        case 2:
            return 1;
        default:
            return exports.fibonacci(n - 1) + exports.fibonacci(n - 2)
    }
}

// 1.3 Sum items in list
aggregate = function ([head, ...tail], fn, initialState) {
    return head == undefined
        ? initialState
        : fn(head, aggregate(tail, fn, initialState));
};

exports.sumList = function (list) {
    var sum = function (x, y) { return x + y; }
    return aggregate(list, sum, 0);
};


//1.4 Count Items In List
exports.lengthOfList = function (list) {
    var add1 = function (x, y) { return 1 + y; }
    return aggregate(list, add1, 0);
};



// 1.5 Filter a list
filterList = function ([head, ...tail], fn) {
    if (head == undefined) {
        return [];
    }

    var rest = filterList(tail, fn);
    if (fn(head)) {
        rest.unshift(head);
    }

    return rest;
}

exports.evensOnly = function (list) {
    var isEven = function (x) { return x % 2 == 0; };
    return filterList(list, isEven);
}


// 1.6 IsEven
exports.isEven = function (n) {
    if (n == 0) {
        return true;
    }
    else {
        return exports.isOdd(n - 1);
    }
}

exports.isOdd = function (n) {
    if (n == 0) {
        return false;
    }
    else {
        return exports.isEven(n - 1);
    }
}


exports.ackermann = function (m, n) {
    if (m == 0) {
        return n + 1;
    }

    if (m > 0 && n == 0) {
        return exports.ackermann(m - 1, 1);
    }

    if (m > 0 && n > 0) {
        return exports.ackermann(m - 1, exports.ackermann(m, n - 1));
    }

}

var fs = require('fs');
exports.findFile = function (filename, folder, done) {

    // Does the file exist in this folder?
    fs.stat(folder + '\\' + filename, function (err, stat) {
        if (err == null) {
            done(folder);
        } else {
            console.log('Some other error: ', err.code);
        }
    });


    // Does the file exist in any subfolders
}


// Binary Tree
var tree = {
    left: [1,2],
    right: [5,3]
}

var maxInTree = function(tree) {
    if (tree.left === undefined) {
        return tree;
    }
    else {
        var maxLeft = maxInTree(tree.left);
        var maxRight = maxInTree(tree.right);
        if (maxLeft > maxRight) {
            return maxLeft;
        }
        else {
            return maxRight;
        }
    }
}
