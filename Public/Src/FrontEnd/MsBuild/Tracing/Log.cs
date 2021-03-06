// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using BuildXL.Tracing;
using BuildXL.Utilities.Instrumentation.Common;
using BuildXL.Utilities.Tracing;

// Suppress missing XML comments on publicly visible types or members
#pragma warning disable 1591

namespace BuildXL.FrontEnd.MsBuild.Tracing
{
    /// <summary>
    /// Logging for the MSBuild frontend and resolvers
    /// </summary>
    [EventKeywordsType(typeof(Events.Keywords))]
    [EventTasksType(typeof(Events.Tasks))]
    public abstract partial class Logger
    {
        /// <summary>
        /// Returns the logger instance
        /// </summary>
        public static Logger Log { get; } = new LoggerImpl();

        // Internal logger will prevent public users from creating an instance of the logger
        internal Logger()
        {
        }

        [GeneratedEvent(
            (ushort)LogEventId.InvalidResolverSettings,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            Keywords = (ushort)(Events.Keywords.UserMessage | Events.Keywords.UserError),
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Invalid resolver settings. {reason}")]
        public abstract void InvalidResolverSettings(LoggingContext context, Location location, string reason);

        [GeneratedEvent(
            (ushort)LogEventId.ProjectGraphConstructionError,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "An error occurred while parsing MsBuild spec files: {message}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void ProjectGraphConstructionError(LoggingContext context, Location location, string message);

        [GeneratedEvent(
            (ushort)LogEventId.CannotFindMsBuildAssembly,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Cannot find the required MsBuild assemblies. Missing assemblies: {missingAssemblyNames}. Searched locations: [{locations}].",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void CannotFindMsBuildAssembly(LoggingContext context, Location location, string locations, string missingAssemblyNames);

        [GeneratedEvent(
            (ushort)LogEventId.UncoordinatedMsBuildAssemblyLocations,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Multiple MsBuild resolvers are present and they differ on the locations to retrieve the required MsBuild assemblies. All these resolvers are required to use the same set of MsBuild assemblies. " +
            "Search locations can be configured by specifying 'MsBuildAssemblyLocations' in the resolver configuration. Locations specified by this resolver are: {locations}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void UncoordinatedMsBuildAssemblyLocations(LoggingContext context, Location location, string locations);

        [GeneratedEvent(
            (ushort)LogEventId.NoSearchLocationsSpecified,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Build parameter 'PATH' is not specified, and no explicit locations were defined in the resolver settings via 'MsBuildAssemblyLocations'.",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void NoSearchLocationsSpecified(LoggingContext context, Location location);

        [GeneratedEvent(
            (ushort)LogEventId.CannotParseBuildParameterPath,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Build parameter 'PATH' cannot be interpreted as a collection of paths: {envPath}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void CannotParseBuildParameterPath(LoggingContext context, Location location, string envPath);

        [GeneratedEvent(
            (ushort)LogEventId.LaunchingGraphConstructionTool,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Verbose,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Launching graph construction tool '{toolPath}' with parameters: {parameters}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void LaunchingGraphConstructionTool(LoggingContext context, Location location, string parameters, string toolPath);

        [GeneratedEvent(
            (ushort)LogEventId.CannotFindParsingEntryPoint,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Cannot find an entry point candidate for parsing under '{rootTraversal}'. If the entry point file is not standard, you can configure one with 'FileNameEntryPoint' in the configuration settings.",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void CannotFindParsingEntryPoint(LoggingContext context, Location location, string rootTraversal);

        [GeneratedEvent(
            (ushort)LogEventId.TooManyParsingEntryPointCandidates,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Too many parsing entry point candidates were found under '{rootTraversal}'. Please configure 'fileNameEntryPoints' in the configuration settings to define the desired list of projects.",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void TooManyParsingEntryPointCandidates(LoggingContext context, Location location, string rootTraversal);

        [GeneratedEvent(
            (ushort)LogEventId.GraphConstructionInternalError,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "An internal error occurred when computing the MsBuild graph. This shouldn't have happened! Tool standard error: '{toolStandardError}'",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void GraphConstructionInternalError(LoggingContext context, Location location, string toolStandardError);

        [GeneratedEvent(
            (ushort)LogEventId.CannotDeleteSerializedGraphFile,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Warning,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Cannot delete file '{file}' containing the serialized MsBuild graph. Details: {message}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void CannotDeleteSerializedGraphFile(LoggingContext context, Location location, string file, string message);

        [GeneratedEvent(
            (ushort)LogEventId.CannotDeleteResponseFile,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Warning,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Cannot delete response file '{file}' containing the arguments for the MsBuild graph construction tool. Details: {message}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void CannotDeleteResponseFile(LoggingContext context, Location location, string file, string message);

        [GeneratedEvent(
            (ushort)LogEventId.GraphConstructionToolCompleted,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Verbose,
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "Graph construction tool finished and found MsBuild.exe under '{pathToMsBuildExe}'. It built a graph using the following MsBuild assemblies:\n{usedMsBuildAssemblies}",
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void GraphConstructionToolCompleted(LoggingContext context, Location location, string usedMsBuildAssemblies, string pathToMsBuildExe);

        [GeneratedEvent(
            (ushort)LogEventId.CycleInBuildTargets,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            Keywords = (ushort)(Events.Keywords.UserMessage | Events.Keywords.UserError),
            EventTask = (ushort)Events.Tasks.Parser,
            Message = "A cycle was detected in build target dependencies, evaluation cannot proceed. Cycle: {cycleDescription}")]
        public abstract void CycleInBuildTargets(LoggingContext context, string cycleDescription);

        [GeneratedEvent(
            (ushort)LogEventId.SchedulingPipFailure,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics),
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "A failure occurred while scheduling a pip. Reason: {detailedFailure}.")]
        public abstract void SchedulingPipFailure(LoggingContext context, Location location, string detailedFailure);

        [GeneratedEvent(
            (ushort)LogEventId.UnexpectedPipBuilderException,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Error,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics),
            EventTask = (ushort)Events.Tasks.Parser,
            Message = Events.LabeledProvenancePrefix + "An unexpected exception occurred while constructing the pip graph. Message: {message}. Stack: {stack}")]
        public abstract void UnexpectedPipBuilderException(LoggingContext context, Location location, string message, string stack);

        [GeneratedEvent(
            (ushort)LogEventId.ReportGraphConstructionProgress,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Informational,
            Message = Events.PhasePrefix + "{message}",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Progress | Events.Keywords.Overwritable))]
        public abstract void ReportGraphConstructionProgress(LoggingContext context, string message);

        [GeneratedEvent(
            (ushort)LogEventId.CannotGetProgressFromGraphConstructionDueToTimeout,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Warning,
            Message = Events.PhasePrefix + "Cannot connect to graph construction progress pipe due to connection timeout. Graph construction progress will not be logged.",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Progress | Events.Keywords.Overwritable))]
        public abstract void CannotGetProgressFromGraphConstructionDueToTimeout(LoggingContext context);

        [GeneratedEvent(
            (ushort)LogEventId.CannotGetProgressFromGraphConstructionDueToUnexpectedException,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Warning,
            Message = Events.PhasePrefix + "The graph construction progress pipe throw an unexpected IO exception. Graph construction progress will not be logged: {message}",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Progress | Events.Keywords.Overwritable))]
        public abstract void CannotGetProgressFromGraphConstructionDueToUnexpectedException(LoggingContext context, string message);

        [GeneratedEvent(
            (ushort)LogEventId.GraphConstructionFinishedSuccessfullyButWithWarnings,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Verbose,
            Message = Events.LabeledProvenancePrefix + "Graph construction process finished successfully, but some warnings occurred: {message}",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void GraphConstructionFinishedSuccessfullyButWithWarnings(LoggingContext context, Location location, string message);

        [GeneratedEvent(
            (ushort)LogEventId.ProjectWithEmptyTargetsIsNotScheduled,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Verbose,
            Message = Events.LabeledProvenancePrefix + "Project '{projectName}' was not scheduled because it does not have any predicted executable targets.",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void ProjectWithEmptyTargetsIsNotScheduled(LoggingContext context, Location location, string projectName);

        [GeneratedEvent(
            (ushort)LogEventId.ProjectIsNotSpecifyingTheProjectReferenceProtocol,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.Warning,
            Message = Events.LabeledProvenancePrefix + "Project '{projectName}' is not specifying its project reference protocol, and therefore the targets to call cannot be inferred. " +
                      "Falling back to calling the project default targets. For more details, see https://github.com/Microsoft/msbuild/blob/master/documentation/specs/static-graph.md",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void ProjectIsNotSpecifyingTheProjectReferenceProtocol(LoggingContext context, Location location, string projectName);

        [GeneratedEvent(
            (ushort)LogEventId.GraphBuilderFilesAreNotRemoved,
            EventGenerators = EventGenerators.LocalOnly,
            EventLevel = Level.LogAlways,
            Message = "Regular deletion of graph-related files is skipped. Graph file produced under '{graphFile}' with arguments '{arguments}'.",
            EventTask = (ushort)Events.Tasks.Engine,
            EventOpcode = (byte)Events.Tasks.Parser,
            Keywords = (int)(Events.Keywords.UserMessage | Events.Keywords.Diagnostics))]
        public abstract void GraphBuilderFilesAreNotRemoved(LoggingContext context, string graphFile, string arguments);
    }
}
