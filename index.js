function calculateConcurrentMerkleTreeByteSize(maxDepth, maxBufferSize) {
  const u64ByteSize = 8;  // Size of u64
  const u32ByteSize = 4;  // Size of u32
  const publicKeyByteSize = 32;  // Size of publicKey

  // ChangeLogInternal structure
  const changeLogByteSize = publicKeyByteSize + (maxDepth * publicKeyByteSize) + u32ByteSize + u32ByteSize;

  // Path structure
  const pathByteSize = (maxDepth * publicKeyByteSize) + publicKeyByteSize + u32ByteSize + u32ByteSize;

  // ConcurrentMerkleTree structure
  const concurrentMerkleTreeByteSize = (
    u64ByteSize * 3 +  // sequenceNumber, activeIndex, bufferSize
    changeLogByteSize * maxBufferSize +
    pathByteSize
  );

  return concurrentMerkleTreeByteSize;
}

function calculateCanopyByteSize(canopyDepth) {
  return Math.max(((1 << (canopyDepth + 1)) - 2) * 32, 0);
}

function calculateConcurrentMerkleTreeHeaderDataV1ByteSize() {
  const u32ByteSize = 4;  // Size of u32
  const u64ByteSize = 8;  // Size of u64
  const publicKeyByteSize = 32;  // Size of publicKey
  const paddingByteSize = 6;  // Size of padding array

  const concurrentMerkleTreeHeaderDataV1ByteSize = (
    u32ByteSize * 2 +  // maxBufferSize, maxDepth
    publicKeyByteSize +
    u64ByteSize +
    paddingByteSize
  );

  return concurrentMerkleTreeHeaderDataV1ByteSize;
}

function getConcurrentMerkleTreeAccountSize(maxDepth, maxBufferSize, canopyDepth, headerVersion = 'V1') {
  if (headerVersion !== 'V1') {
    throw new Error('Unsupported header version');
  }

  const accountDiscriminantByteSize = 1;
  const headerVersionByteSize = 1;

  const totalByteSize = (
    accountDiscriminantByteSize +
    headerVersionByteSize +
    calculateConcurrentMerkleTreeHeaderDataV1ByteSize() +
    calculateConcurrentMerkleTreeByteSize(maxDepth, maxBufferSize) +
    (canopyDepth ? calculateCanopyByteSize(canopyDepth) : 0)
  );

  return totalByteSize;
}

function numberFormatter(num) {
  return new Intl.NumberFormat(undefined, {
    maximumFractionDigits: 4,
  }).format(num);
}

async function GET_RENT(bytes) {
  const response = await fetch(
    'https://api.devnet.solana.com/',
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        method: "getMinimumBalanceForRentExemption",
        jsonrpc: "2.0",
        params: [bytes],
        id: "263f4596-4ed4-4208-b02a-31126e3b95c6"
      })
    }
  );

  const data = await response.json();
  console.log(data);
  return data.result;
}

async function CALCULATE_TREE_RENT (buffer, depth, canopy) {
  return await GET_RENT(getConcurrentMerkleTreeAccountSize(buffer, depth, canopy))/1000000000;
}

// Example usage
const maxDepth = 20;  // Replace this with the desired maxDepth value
const maxBufferSize = 1024;  // Replace this with the desired maxBufferSize value
const canopyDepth = 0;  // Replace this with the desired canopyDepth value (optional)
const size = getConcurrentMerkleTreeAccountSize(maxDepth, maxBufferSize, canopyDepth);
console.log(`Concurrent Merkle Tree Account Size: ${size} bytes`);

const rent = await CALCULATE_TREE_RENT(maxDepth, maxBufferSize, canopyDepth);
console.log(`Concurrent Merkle Tree Account Price: ${numberFormatter(rent)} sol`);
