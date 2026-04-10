/* O A
OO OA AO AA 
OOO OOA OAO OAA AOO AOA AAO 
OOOO OOOA OOAO OOAA OAOO OAOA OAAO AOOO AOOA AOAO AOAA AAOO AAOA */
let end = {O: 1, OA : 1, AA: 0}
let numO = {O: 1, OA : 0, AA: 0}
for (let i = 0; i < 29; i++) {
  let temp = {...end};
  let tempNum = {...numO};
  end.O = temp.O + temp.OA + temp.AA
  end.OA = temp.O
  end.AA = temp.OA
  numO.O = tempNum.O + tempNum.OA + tempNum.AA + end.O
  numO.OA = tempNum.O
  numO.AA = tempNum.OA
  // console.log(`${i+2} jour`)
  // console.log(end)
  // console.log(end.O + end.OA + end.AA)
  // console.log(numO)
  // console.log(numO.O + numO.OA + numO.AA)
  console.log(numO.O + numO.OA + numO.AA + end.O + end.OA + end.AA)
}


