var expect = require("chai").expect;
var solution = require("../solutions.js");

describe("Factorial", function () {
    it("0! = 1,  1!=1 and 5!=120", function () {
        expect(solution.factorial(0)).to.equal(1);
        expect(solution.factorial(1)).to.equal(1);
        expect(solution.factorial(5)).to.equal(120);
    });
});

describe("Fibonacci", function () {
    it("Series is 1 1 2 3 5 8", function () {
        expect(solution.fibonacci(1)).to.equal(1);
        expect(solution.fibonacci(2)).to.equal(1);
        expect(solution.fibonacci(3)).to.equal(2);
        expect(solution.fibonacci(4)).to.equal(3);
        expect(solution.fibonacci(5)).to.equal(5);
        expect(solution.fibonacci(6)).to.equal(8);
    });
});

describe("SumList", function () {
    it("SumList [] = 0", function () {
        expect(solution.sumList([])).to.equal(0);
        expect(solution.sumList([5])).to.equal(5);
        expect(solution.sumList([1,2,3,4,5])).to.equal(15);
    });
});

describe("LengthOfList", function () {
    it("lengthOfList [] = 0", function () {
        expect(solution.lengthOfList([])).to.equal(0);
        expect(solution.lengthOfList([5])).to.equal(1);
        expect(solution.lengthOfList([1,2,3,4,5])).to.equal(5);
    });
});

describe("EvensOnly", function () {
    it("evensOnly [] = 0", function () {
        expect(solution.evensOnly([])).to.deep.equal([]);
        expect(solution.evensOnly([5])).to.deep.equal([]);
        expect(solution.evensOnly([1,2,3,4,5])).to.deep.equal([2,4]);
        expect(solution.evensOnly([1,2,3,4,5,6,7,8,9,10])).to.deep.equal([2,4,6,8,10]);
    });
});

describe("IsEven", function () {
    it("isEven 4 = true", function () {
        expect(solution.isEven(3)).to.equal(false);
        expect(solution.isEven(4)).to.equal(true);
    });
});


describe("Ackermann", function () {
    it("ackermann(3,10) = 8189", function () {
        expect(solution.ackermann(3,10)).to.equal(8189);
    });
});


describe("FindFile", function () {
    it("findFile('test.ts', 'c:\') = 'c:\temp'", function (done) {
        solution.findFile('test.ts', 'c:\\', done);
        expect(solution.findFile('test.ts', 'c:\\')).to.deep.equal(['c:\temp']);
    });
});


