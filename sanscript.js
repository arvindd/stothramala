import Sanscript from "@sanskrit-coders/sanscript";

function sanscript(input, from, to) {
  return Sanscript.t(input, from, to)
}

var input = process.argv[2]
var from = process.argv[3]
var to = process.argv[4]

console.log("Input: ", input)

var output = sanscript(input, from, to)
console.log(output)
