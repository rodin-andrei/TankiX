namespace YamlDotNet.Core
{
	internal enum ParserState
	{
		StreamStart = 0,
		StreamEnd = 1,
		ImplicitDocumentStart = 2,
		DocumentStart = 3,
		DocumentContent = 4,
		DocumentEnd = 5,
		BlockNode = 6,
		BlockNodeOrIndentlessSequence = 7,
		FlowNode = 8,
		BlockSequenceFirstEntry = 9,
		BlockSequenceEntry = 10,
		IndentlessSequenceEntry = 11,
		BlockMappingFirstKey = 12,
		BlockMappingKey = 13,
		BlockMappingValue = 14,
		FlowSequenceFirstEntry = 15,
		FlowSequenceEntry = 16,
		FlowSequenceEntryMappingKey = 17,
		FlowSequenceEntryMappingValue = 18,
		FlowSequenceEntryMappingEnd = 19,
		FlowMappingFirstKey = 20,
		FlowMappingKey = 21,
		FlowMappingValue = 22,
		FlowMappingEmptyValue = 23,
	}
}
