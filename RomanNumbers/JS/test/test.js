var should = require('chai').should();
var RomanNumber = require('../app/app.js').RomanNumber;

describe('number to roman V1', function() {
    let romanTraslator = new RomanNumber()
    it('1 to 10', function() {
        [[1, 'I'],[2, 'II'],[3, 'III'],[4, 'IV'],[5, 'V'],[6, 'VI'],[7, 'VII'],[8, 'VIII'],[9, 'IX'],[10, 'X']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumberV1(input).should.equal(expected))
    }); 

    it('11 to 100', function() {
        [[11, 'XI'],[12, 'XII'],[21,'XXI'],[32, 'XXXII'],[42, 'XLII'],[50, 'L'],[59, 'LIX'],[69, 'LXIX']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumberV1(input).should.equal(expected))
    }); 

    it('100 to 1000', function() {
        [[459, 'CDLIX'],[691, 'DCXCI'],[999, 'CMXCIX'],[1000, 'M']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumberV1(input).should.equal(expected))
    });

    it('1000 to 4999', function() {
        [[2167, 'MMCLXVII'],[3672, 'MMMDCLXXII'],[4999, 'MMMMCMXCIX']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumberV1(input).should.equal(expected))
    });
});

describe('number to roman testing', function() {
    let romanTraslator = new RomanNumber()
    it('1 to 10', function() {
        [[1, 'I'],[2, 'II'],[3, 'III'],[4, 'IV'],[5, 'V'],[6, 'VI'],[7, 'VII'],[8, 'VIII'],[9, 'IX'],[10, 'X']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumber(input).should.equal(expected))
    }); 

    it('11 to 100', function() {
        [[11, 'XI'],[12, 'XII'],[21,'XXI'],[32, 'XXXII'],[42, 'XLII'],[50, 'L'],[59, 'LIX'],[69, 'LXIX']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumber(input).should.equal(expected))
    }); 

    it('100 to 1000', function() {
        [[459, 'CDLIX'],[494,'CDXCIV'],[691, 'DCXCI'],[999, 'CMXCIX'],[1000, 'M']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumber(input).should.equal(expected))
    });

    it('1000 to 4999', function() {
        [[2167, 'MMCLXVII'],[3672, 'MMMDCLXXII'],[4999, 'MMMMCMXCIX']]
        .forEach(([input, expected]) => romanTraslator.RomanToNumber(input).should.equal(expected))
    });
});
