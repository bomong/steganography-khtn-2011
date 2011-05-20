function [z,y] = mySVM(TrainingData,TestingData,TrainCount,TestCount)
%1 lay du lieu
TrainingGroup= 'gooddata';
for k=2:TrainCount(1)
    TrainingGroup= [TrainingGroup;'gooddata'];
end
for k=1:TrainCount(2)
    TrainingGroup= [TrainingGroup;'bad_data'];
end
TestingGroup= 'gooddata';
for k=2:TestCount(1)
    TestingGroup= [TestingGroup;'gooddata'];
end
for k=2:TestCount(2)
    TestingGroup= [TestingGroup;'bad_data'];
end
%2 huan luyen
 options = optimset('maxiter',1000);
svmStruct=svmtrain(TrainingData,TrainingGroup,'quadprog_opts',options,'showplot',true);
%3 kiem tra
[n,m]=size(TestingData);
group=svmclassify(svmStruct,TestingData,'showplot',true);
z=0;
for k=1:TestCount(1)
    if isequal (group(k,:),TestingGroup(k,:))
        z=z+1;
    end
end
y=0;
for k=1:TestCount(2)
    if isequal (group(k+TestCount(1),:),TestingGroup(k,:))
        y=y+1;
    end
end


