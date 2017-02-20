
exports.RomanNumber = function () {
    let letters = ['I', 'V', 'X', 'L', 'C', 'D', 'M', 'MMM']

    function genUnit(nb, letters) {
        if (nb <= 3) return letters[0].repeat(nb)
        else if (nb === 4) return letters[0] + letters[1]
        else if (nb <= 8) return letters[1] + letters[0].repeat(nb - 5)
        else if (nb === 9) return letters[0] + letters[2]
    }

    function decToRom(nb, unitPos = 0) {
        return ((nb >= Math.pow(10, unitPos + 1)) ? decToRom(nb, unitPos + 1) : '') +
            genUnit(Math.floor(nb % Math.pow(10, unitPos + 1) / Math.pow(10, unitPos)), letters.slice(unitPos * 2))
    }

    function RomanToNumberV1(nb) {
        if (nb < 10) return genUnit(nb, letters)
        else if (nb < 100) return genUnit(Math.floor(nb / 10), letters.slice(2)) + decToRom(nb % 10)
        else if (nb < 1000) return genUnit(Math.floor(nb / 100), letters.slice(4)) + decToRom(nb % 100)
        else if (nb <= 4999) return genUnit(Math.floor(nb / 1000), letters.slice(6)) + decToRom(nb % 1000)
        throw new Error('Cannot compute this number:' + nb)
    }

    return {
        RomanToNumber: decToRom,
        RomanToNumberV1: RomanToNumberV1
    }
}
