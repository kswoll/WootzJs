//QUnit.moduleStart({ name })
QUnit.moduleStart = function (settings) {
    console.log("##teamcity[testSuiteStarted name='" + settings.name + "']");
};

//QUnit.moduleDone({ name, failed, passed, total })
QUnit.moduleDone = function (settings) {
    console.log("##teamcity[testSuiteFinished name='" + settings.name + "']");
};

//QUnit.testStart({ name })
QUnit.testStart = function (settings) {
    console.log("##teamcity[testStarted name='" + settings.name + "']");
};

//QUnit.testDone({ name, failed, passed, total })
QUnit.testDone = function (settings) {
    if (settings.failed > 0) {
        console.log("##teamcity[testFailed name='" + settings.name + "'"
                     + " message='Assertions failed: " + settings.failed + "'"
                     + " details='Assertions failed: " + settings.failed + "']");
    }
    console.log("##teamcity[testFinished name='" + settings.name + "']");
};
