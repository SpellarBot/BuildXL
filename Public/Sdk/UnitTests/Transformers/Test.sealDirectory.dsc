// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import {Assert, Testing} from "Sdk.Testing";
import {Transformer} from "Sdk.Transformers";

namespace Sdk.Tests {
    @@Testing.unitTest()
    export function sealDirectory() {
        Transformer.sealDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`],
        });
    }
    
    @@Testing.unitTest()
    export function sealDirectoryWithTags() {
        Transformer.sealDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`],
            tags: ["aTag", "zTag"],
        });
    }
    
    @@Testing.unitTest()
    export function sealDirectoryWithDescription() {
        Transformer.sealDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`], 
            description: "Custom Description",
        });
    }
    
    @@Testing.unitTest()
    export function sealDirectoryWithScrub() {
        Transformer.sealDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`],
            scrub: true,
        });
    }

    @@Testing.unitTest()
    export function sealPartialDirectory() {
        Transformer.sealPartialDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`],
        });
    }

    @@Testing.unitTest()
    export function sealPartialDirectoryWithTags() {
        Transformer.sealPartialDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`],
            tags: ["aTag", "zTag"],
        });
    }

    @@Testing.unitTest()
    export function sealPartialDirectoryWithDescription() {
        Transformer.sealPartialDirectory({
            root: d`src`,
            files: [f`src/file1`, f`src/file2`],
            description: "Custom Description",
        });
    }
    
    @@Testing.unitTest()
    export function sealSourceDirectoryAllDirectories() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "allDirectories",
        });
    }
    
    @@Testing.unitTest()
    export function sealSealSourceDirectoryAllDirectoriesWithTags() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "allDirectories",
            tags: ["aTag", "zTag"]
        });
    }
    
    @@Testing.unitTest()
    export function sealSealSourceDirectoryAllDirectoriesWithDescription() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "allDirectories",
            description: "Custom description",
        });
    }
    
    @@Testing.unitTest()
    export function sealSourceDirectoryTopDirectoryOnlyDefault() {
        Transformer.sealSourceDirectory({
            root: d`src`,
        });
    }
    
    @@Testing.unitTest()
    export function sealSourceDirectoryTopDirectoryOnly() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "topDirectoryOnly",
        });
    }
    
    @@Testing.unitTest()
    export function sealSealSourceDirectoryTopDirectoryOnlyWithTags() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "topDirectoryOnly",
            tags: ["aTag", "zTag"]
        });
    }
    
    @@Testing.unitTest()
    export function sealSealSourceDirectoryAllDirectoriesWithPatterns() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "allDirectories",
            tags: ["aTag", "zTag"], 
            description: "Custom description",
            patterns: ["*.cs", ".txt"],
        });
    }
    
    @@Testing.unitTest()
    export function sealSealSourceDirectoryTopDirectoryOnlyWithPatterns() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "topDirectoryOnly",
            patterns: ["*.cs", ".txt"],
        });
    }

    @@Testing.unitTest()
    export function sealSealSourceDirectoryTopDirectoryWithPatterns() {
        Transformer.sealSourceDirectory({
            root: d`src`,
            include: "topDirectoryOnly",
            tags: ["aTag", "zTag"],
            description: "description",
            patterns: ["*.cs", ".txt"],
        });
    }

    @@Testing.unitTest()
    export function inspectingSealDirectoryKindIsAllowed() {
        // Any type of static directory will do, we are not checking the kind matches the operation, which is already
        // checked in a unit test, but that 'kind' is properly exposed as an instance member
        const sourceSeal = Transformer.sealSourceDirectory(d`src`);
        const kind = sourceSeal.kind;
    }
}
