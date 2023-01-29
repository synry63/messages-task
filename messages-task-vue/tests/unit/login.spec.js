import { shallowMount } from '@vue/test-utils'
import Login from '@/components/Login.vue'

test('is valid email input', async () => {
    const wrapper = shallowMount(Login)

    const textInput = wrapper.find('input#email-input')
    await textInput.setValue('toto@company.com')

    expect(wrapper.vm.isValidEmail).toBe(true)
})
