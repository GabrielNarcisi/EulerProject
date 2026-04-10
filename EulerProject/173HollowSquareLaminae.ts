//4nm + 4n² = n(4n + 4m) = k
//m = (k - 4n²)/4n

function radical (n: number): number[] {
  let result: number[] = [];
  for (let i = 0; i < Math.sqrt(n); i++) {
    if(n%i === 0) {
      result.push(i)
    }
  }
  return result;
}
const SIZE = 1000000
let n = 0;
for (let i = 8; i <= SIZE; i += 4) {
  n += radical(i).filter(r => i > 4*r*r && ((i - 4*r*r)%(4*r) === 0)).length <= 10 ? 1:0;
}
console.log(n)
