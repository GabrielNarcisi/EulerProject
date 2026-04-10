const SIZE = 100000;

function radical(n: number, primeList: number[]) : number {
  return primeList.filter(p => n%p === 0).reduce((a,b) => a*b, 1);
}

function primeList() : number[] {
  let result: number[] = [];
  for (let i = 2; i <= SIZE; i++) {
    if(!result.some(n => i%n === 0)) {
      result.push(i);
    };
  }
  return result;
}

let pList = primeList();
let rad: Map<number, number> = new Map;
for (let i = 1; i <= SIZE; i++) {
  rad.set(i, radical(i, pList))
}
const sortedEntries = Array.from(rad).sort((a, b) => a[1] - b[1]);
console.log(sortedEntries.at(9999))