import { useState } from 'react';
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Checkbox } from "@/components/ui/checkbox";
import { toast } from "sonner";

const Index = () => {
  const [totalBudget, setTotalBudget] = useState('');
  const [agencyFee, setAgencyFee] = useState('');
  const [thirdPartyFee, setThirdPartyFee] = useState('');
  const [workingHoursFee, setWorkingHoursFee] = useState('');
  const [newAd, setNewAd] = useState({ name: '', fee: '', enhanced: false });
  const [ads, setAds] = useState([]);

  const queryClient = useQueryClient();

  const { data: budgetData } = useQuery({
    queryKey: ['budget'],
    queryFn: () => fetch('api/solution/getbudget').then(res => res.json()),
  });

  const { data: agencyFeeData } = useQuery({
    queryKey: ['agencyFee'],
    queryFn: () => fetch('api/solution/agencyfee').then(res => res.json()),
  });

  const { data: thirdPartyFeeData } = useQuery({
    queryKey: ['thirdPartyFee'],
    queryFn: () => fetch('api/solution/getthirdpartyfee').then(res => res.json()),
  });

  const { data: workingHoursFeeData } = useQuery({
    queryKey: ['workingHoursFee'],
    queryFn: () => fetch('api/solution/getworkinghoursfee').then(res => res.json()),
  });

  const addAdMutation = useMutation({
    mutationFn: (newAd) => fetch(`api/solution/getnewad/${newAd.name}`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newAd),
    }).then(res => res.json()),
    onSuccess: () => {
      queryClient.invalidateQueries('ads');
      setAds([...ads, newAd]);
      setNewAd({ name: '', fee: '', enhanced: false });
      toast.success('Advertisement added successfully');
    },
  });

  const deleteAdMutation = useMutation({
    mutationFn: (name) => fetch(`api/solution/deletead${name}`, { method: 'DELETE' }).then(res => res.json()),
    onSuccess: (data, variables) => {
      queryClient.invalidateQueries('ads');
      setAds(ads.filter(ad => ad.name !== variables));
      toast.success('Advertisement deleted successfully');
    },
  });

  const runAlgorithmMutation = useMutation({
    mutationFn: () => fetch('api/solution/runalgorithm', { method: 'POST' }).then(res => res.json()),
    onSuccess: () => {
      toast.success('Algorithm run successfully');
    },
  });

  const handleAddAd = () => {
    if (newAd.name && newAd.fee) {
      addAdMutation.mutate(newAd);
    }
  };

  const handleDeleteAd = (name) => {
    deleteAdMutation.mutate(name);
  };

  const handleRunAlgorithm = () => {
    runAlgorithmMutation.mutate();
  };

  return (
    <div className="min-h-screen p-8 bg-gray-100">
      <div className="max-w-4xl mx-auto bg-white rounded-lg shadow-md p-6">
        <h1 className="text-3xl font-bold mb-6">Budget and Advertisement Management</h1>
        
        <div className="grid grid-cols-2 gap-4 mb-6">
          <div>
            <label className="block mb-2">Total Budget</label>
            <Input
              type="number"
              value={totalBudget}
              onChange={(e) => setTotalBudget(e.target.value)}
              placeholder="Enter total budget"
            />
          </div>
          <div>
            <label className="block mb-2">Agency Fee (0-1)</label>
            <Input
              type="number"
              value={agencyFee}
              onChange={(e) => setAgencyFee(Math.min(1, Math.max(0, e.target.value)))}
              placeholder="Enter agency fee"
              min="0"
              max="1"
              step="0.01"
            />
          </div>
          <div>
            <label className="block mb-2">Third Party Fee (0-1)</label>
            <Input
              type="number"
              value={thirdPartyFee}
              onChange={(e) => setThirdPartyFee(Math.min(1, Math.max(0, e.target.value)))}
              placeholder="Enter third party fee"
              min="0"
              max="1"
              step="0.01"
            />
          </div>
          <div>
            <label className="block mb-2">Working Hours Fee</label>
            <Input
              type="number"
              value={workingHoursFee}
              onChange={(e) => setWorkingHoursFee(e.target.value)}
              placeholder="Enter working hours fee"
            />
          </div>
        </div>

        <h2 className="text-2xl font-semibold mb-4">Add New Advertisement</h2>
        <div className="flex space-x-4 mb-6">
          <Input
            value={newAd.name}
            onChange={(e) => setNewAd({...newAd, name: e.target.value})}
            placeholder="Ad Name"
          />
          <Input
            type="number"
            value={newAd.fee}
            onChange={(e) => setNewAd({...newAd, fee: e.target.value})}
            placeholder="Ad Fee"
          />
          <div className="flex items-center">
            <Checkbox
              id="enhanced"
              checked={newAd.enhanced}
              onCheckedChange={(checked) => setNewAd({...newAd, enhanced: checked})}
            />
            <label htmlFor="enhanced" className="ml-2">Enhanced</label>
          </div>
          <Button onClick={handleAddAd}>Add Ad</Button>
        </div>

        <h2 className="text-2xl font-semibold mb-4">Advertisement List</h2>
        <ul className="space-y-2 mb-6">
          {ads.map((ad, index) => (
            <li key={index} className="flex justify-between items-center bg-gray-100 p-2 rounded">
              <span>{ad.name} - Fee: {ad.fee} {ad.enhanced ? '(Enhanced)' : ''}</span>
              <Button variant="destructive" onClick={() => handleDeleteAd(ad.name)}>Delete</Button>
            </li>
          ))}
        </ul>

        <Button onClick={handleRunAlgorithm} className="w-full">Run Algorithm</Button>
      </div>
    </div>
  );
};

export default Index;
