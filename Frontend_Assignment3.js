// Yu Wang

//1
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
}
let sum = 0;
for (let p in salaries) {
    sum += salaries[p];
}
console.log(sum); //390

//2
let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};
function multiplyNumeric(obj) {
    for (let p in obj) {
        if (isNaN(p)) continue;
        obj[p] *= 2
    }
}

multiplyNumeric(menu);
console.log(menu);
/*
menu = {
    width: 400,
    height: 600,
    title: "My menu"
};
*/

//3
function checkEmailId(str) {
    let re = /@[a-zA-Z]+\./;
    return (re.test(str))
}
console.log(checkEmailId('@.')) // false
console.log(checkEmailId('@')) // false
console.log(checkEmailId('.')) // false
console.log(checkEmailId('@a.')) // true
console.log(checkEmailId('a@ab.a')) // true

//4
function truncate(str, maxlength) {
    return str.length > maxlength ? str.substring(0, maxlength-1) + "…" : str
}
console.log(truncate("What I'd like to tell on this topic is:", 20)); //"What I'd like to te…"
console.log(truncate("Hi everyone!", 20)); //"Hi everyone!"

//5
let styles = ["James", "Brennie"]
console.log(styles) //James, Brennie
styles.push("Robert")
console.log(styles) //James, Brennie, Robert
styles[parseInt(styles.length/2)] = "Calvin"
console.log(styles) //James, Calvin, Robert
console.log(styles.shift()) //James
console.log(styles) //Calvin, Robert
styles.unshift("Regal")
styles.unshift("Rose")
console.log(styles) //Rose, Regal, Calvin, Robert

//6
function luhnCheck(number) {
    let sum = 0;
    for (let i = 0; i < number.length - 1; i++) {
        sum += parseInt(number[i]) * 2;
    }
    return (sum % 10) == number.charAt(number.length-1)
}

function isAllowed(number, prefix) {
    for (let p in prefix) {
        if (number.substring(0, p.length) === p) return false;
    }
    return true;
}

function validateCards(cardsToValidate, bannedPrefixes) {
    res = []
    for (let number of cardsToValidate) {
        obj = {
            card: number,
            isValid: luhnCheck(number),
            isAllowed: isAllowed(number, bannedPrefixes)
        }
        res.push(obj)
    }
    return JSON.stringify(res)
}

let cardsToValidate = ["6724843711060148"]
let bannedPrefixes = ["11", "3434", "67453", "9"]
console.log(validateCards(cardsToValidate, bannedPrefixes)) //[{"card":"6724843711060148","isValid":true,"isAllowed":true}]
