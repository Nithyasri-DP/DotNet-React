using InsuranceClaimProcessor.Interfaces;
using InsuranceClaimProcessor.Models;
using InsuranceClaimProcessor.Services;
using Moq;

namespace InsuranceClaimTestProject
{
    [TestFixture]
    public class ClaimProcessorTests
    {
        private Mock<IPolicyRepository> _policyRepoMock;
        private Mock<IClaimEvaluator> _claimEvaluatorMock;
        private ClaimProcessor _claimProcessor;

        [SetUp]
        public void Setup()
        {
            _policyRepoMock = new Mock<IPolicyRepository>();
            _claimEvaluatorMock = new Mock<IClaimEvaluator>();
            _claimProcessor = new ClaimProcessor(_policyRepoMock.Object, _claimEvaluatorMock.Object);
        }

        [Test]
        public void SubmitClaim_ValidClaim_ShouldApprove()
        {
            var policy = new Policy { PolicyId = 1, PolicyType = "Health", IsActive = true, MaxClaimAmount = 10000 };
            var claim = new Claim { ClaimId = 1, PolicyId = 1, ClaimType = "Health", ClaimedAmount = 5000 };

            _policyRepoMock.Setup(x => x.GetPolicyById(1)).Returns(policy);
            _claimEvaluatorMock.Setup(x => x.CalculatePayout(claim, policy)).Returns(4000);

            var result = _claimProcessor.SubmitClaim(claim);

            Assert.AreEqual("Approved", result.Status);
            Assert.AreEqual(4000, result.ApprovedAmount);
        }

        [Test]
        public void SubmitClaim_ClaimExceedsLimit_ShouldReject()
        {
            var policy = new Policy { PolicyId = 1, PolicyType = "Health", IsActive = true, MaxClaimAmount = 3000 };
            var claim = new Claim { ClaimId = 1, PolicyId = 1, ClaimType = "Health", ClaimedAmount = 5000 };

            _policyRepoMock.Setup(x => x.GetPolicyById(1)).Returns(policy);

            var result = _claimProcessor.SubmitClaim(claim);

            Assert.AreEqual("Rejected", result.Status);
            Assert.IsNull(result.ApprovedAmount);
        }

        [Test]
        public void SubmitClaim_PolicyInactive_ShouldReject()
        {
            var policy = new Policy { PolicyId = 1, PolicyType = "Health", IsActive = false, MaxClaimAmount = 10000 };
            var claim = new Claim { ClaimId = 1, PolicyId = 1, ClaimType = "Health", ClaimedAmount = 5000 };

            _policyRepoMock.Setup(x => x.GetPolicyById(1)).Returns(policy);

            var result = _claimProcessor.SubmitClaim(claim);

            Assert.AreEqual("Rejected", result.Status);
            Assert.IsNull(result.ApprovedAmount);
        }
    }
}
