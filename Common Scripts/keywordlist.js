var keywordString = "how azure works,azure vs aws,how azure cloud works,how azure works internally,what is microsoft azure,how microsoft azure works,what's microsoft azure,azure how it works,azure data center,azure datacenters,azure what is it,azure what is it used for,azure how to use,how does azure works,how does azure work,how does azure cloud work"

var keywords = keywordString.split(',').map(i=>i.trim().toLowerCase())
var outputKeywords = JSON.parse(JSON.stringify(keywords))

// TRANSFORMATIONS

// duplicate vs/and
let flipWords = ['vs', 'and']
function getFlipped(keyword, middleWord){
    let split = keyword.split(middleWord)
    return split[1]+' '+middleWord+' '+split[0]
}
for(var i=0;i<keywords.length;i++){
    let keyword = keywords[i]
    for(var j=0;j<flipWords.length;j++){
        let flipWord = flipWords[j]
        if(keyword.indexOf(flipWord)>-1){
            var flipped = getFlipped(keyword, flipWord)
            outputKeywords.push(flipped)
        }
    }
}

var outputKeywords = outputKeywords.map(i=>i.trim().toLowerCase())

console.log(outputKeywords)
console.log(outputKeywords.reduce((i,j)=>i+','+j))