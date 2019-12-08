
uint iSeed;

float hash()
{
	iSeed += (iSeed << 10u);
	iSeed ^= (iSeed >>  6u);
	iSeed += (iSeed <<  3u);
	iSeed ^= (iSeed >> 11u);
	iSeed += (iSeed << 15u);

	const uint ieeeMantissa = 0x007FFFFFu;
	const uint ieeeOne      = 0x3F800000u;

	uint tmp = iSeed;
	tmp &= ieeeMantissa;
	tmp |= ieeeOne;

	return asfloat(tmp) - 1.0;
}

float  rand()  { return hash(); }
float2 rand2() { return float2(hash(), hash()); }
float3 rand3() { return float3(hash(), hash(), hash()); }
float3 rand4() { return float4(hash(), hash(), hash(), hash()); }