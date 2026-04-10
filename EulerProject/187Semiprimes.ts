const SIZE = 100000000;

function primeList(): number[] {
  let result: number[] = [];
  for (let i = 2; i <= SIZE / 2; i++) {
    if (!result.some(n => i % n === 0)) {
      result.push(i);
    };
  }
  return result;
}

let n = 0;
let pList = primeList()
console.log(pList)
pList.forEach(p1 => {
  pList.forEach(p2 => n += p1 * p2 < SIZE && p1 <=p2 ? 1 : 0)
})
console.log(n);